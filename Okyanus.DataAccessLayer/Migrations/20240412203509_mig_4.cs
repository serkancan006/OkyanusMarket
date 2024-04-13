using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okyanus.DataAccessLayer.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlternatifUrun",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderUserPhone",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeslimatSaati",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeslimatYontemi",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternatifUrun",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderUserPhone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TeslimatSaati",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TeslimatYontemi",
                table: "Orders");
        }
    }
}
