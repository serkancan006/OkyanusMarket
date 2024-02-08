using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okyanus.DataAccessLayer.Migrations
{
    public partial class mig_10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderAdress",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderApartman",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderDaire",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderFirstName",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderIlce",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderKat",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderMail",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderPhone",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderSehir",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderSurname",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderAdress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderApartman",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderDaire",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderFirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderIlce",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderKat",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderMail",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderPhone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderSehir",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderSurname",
                table: "Orders");
        }
    }
}
