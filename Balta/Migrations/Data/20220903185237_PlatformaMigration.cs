using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Balta.Migrations.Data
{
    public partial class PlatformaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Cursos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Cursos");
        }
    }
}
