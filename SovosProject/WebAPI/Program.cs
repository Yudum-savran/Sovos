using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using SovosProject.Application.Email;
using SovosProject.Application.FluentValitaion.Validators;
using SovosProject.Application.Interfaces;
using SovosProject.Application.Services;
using SovosProject.Core.Repository;
using SovosProject.Infrastructure.Data;
using SovosProject.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SovosProjectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration"));

builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IEmailLogRepository, EmailLogRepository>();
builder.Services.AddTransient<IInvoiceEmailService, InvoiceEmailService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddAutoMapper(typeof(SovosProject.Application.AutoMappers.AutoMapper));
builder.Services.AddValidatorsFromAssemblyContaining<InvoiceValidator>();


// appsettings.json'u yükleyerek konfigürasyonu Serilog'a aktar
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Serilog'u konfigürasyondan oku
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

// Web uygulamasına Serilog'u dahil et
builder.Host.UseSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
