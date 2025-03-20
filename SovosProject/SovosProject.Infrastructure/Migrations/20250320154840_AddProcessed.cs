using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SovosProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProcessed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Processed",
                table: "InvoiceHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Unprocessed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Processed",
                table: "InvoiceHeaders");
        }
    }
}
