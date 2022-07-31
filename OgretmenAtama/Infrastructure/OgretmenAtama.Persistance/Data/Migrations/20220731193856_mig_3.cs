using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OgretmenAtama.Persistance.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BosKontenjan",
                table: "Kurumlar");

            migrationBuilder.AddColumn<int>(
                name: "BosKontenjan",
                table: "KurumlarAlanlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BosKontenjan",
                table: "KurumlarAlanlar");

            migrationBuilder.AddColumn<int>(
                name: "BosKontenjan",
                table: "Kurumlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
