using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Clinica.Migrations
{
    public partial class schimbareint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Durata",
                table: "Serviciu",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Durata",
                table: "Serviciu",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
