using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okyanus.DataAccessLayer.Migrations
{
    public partial class mig_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "vizyon",
                table: "Abouts",
                newName: "Vizyon");

            migrationBuilder.RenameColumn(
                name: "misyon",
                table: "Abouts",
                newName: "Misyon");

            migrationBuilder.AddColumn<string>(
                name: "AboutDesc",
                table: "Abouts",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutDesc",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "Vizyon",
                table: "Abouts",
                newName: "vizyon");

            migrationBuilder.RenameColumn(
                name: "Misyon",
                table: "Abouts",
                newName: "misyon");
        }
    }
}
