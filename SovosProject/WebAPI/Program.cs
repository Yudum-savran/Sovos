using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SovosProject.Application.Interfaces;
using SovosProject.Application.Services;
using SovosProject.Application.Validators;
using SovosProject.Core.Repository;
using SovosProject.Infrastructure.Data;
using SovosProject.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SovosProjectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddAutoMapper(typeof(SovosProject.Application.AutoMappers.AutoMapper));
builder.Services.AddValidatorsFromAssemblyContaining<InvoiceValidator>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
