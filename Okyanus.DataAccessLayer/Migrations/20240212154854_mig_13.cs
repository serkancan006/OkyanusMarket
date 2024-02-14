using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okyanus.DataAccessLayer.Migrations
{
    public partial class mig_13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductType",
                table: "Products",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ProductType",
                table: "Products",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");
        }
    }
}
