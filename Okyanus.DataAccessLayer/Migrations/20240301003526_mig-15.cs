using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okyanus.DataAccessLayer.Migrations
{
    public partial class mig15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<double>(
                name: "Count",
                table: "OrderDetails",
                type: "BINARY_DOUBLE",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "OrderDetails",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE");
        }
    }
}
