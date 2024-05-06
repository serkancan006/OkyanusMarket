using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okyanus.DataAccessLayer.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AnaBarcode",
                table: "Products",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AnaBarcode",
                table: "Products",
                column: "AnaBarcode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_AnaBarcode",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "AnaBarcode",
                table: "Products",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");
        }
    }
}
