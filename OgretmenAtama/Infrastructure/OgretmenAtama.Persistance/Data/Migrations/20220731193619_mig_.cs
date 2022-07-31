using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OgretmenAtama.Persistance.Migrations
{
    public partial class mig_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlanKodu",
                table: "Kurumlar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlanKodu",
                table: "Kurumlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
