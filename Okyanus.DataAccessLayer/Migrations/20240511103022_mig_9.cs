using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okyanus.DataAccessLayer.Migrations
{
    public partial class mig_9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "IncreaseAmount",
                table: "ProductTypes",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE");

            migrationBuilder.AlterColumn<decimal>(
                name: "Stock",
                table: "Products",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountedPrice",
                table: "Products",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Orders",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "OrderDetails",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "OrderDetails",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE");

            migrationBuilder.AlterColumn<decimal>(
                name: "Count",
                table: "OrderDetails",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "IncreaseAmount",
                table: "ProductTypes",
                type: "BINARY_DOUBLE",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<int>(
                name: "Stock",
                table: "Products",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                type: "BINARY_DOUBLE",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "DiscountedPrice",
                table: "Products",
                type: "BINARY_DOUBLE",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "Orders",
                type: "BINARY_DOUBLE",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "UnitPrice",
                table: "OrderDetails",
                type: "BINARY_DOUBLE",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "OrderDetails",
                type: "BINARY_DOUBLE",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "Count",
                table: "OrderDetails",
                type: "BINARY_DOUBLE",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");
        }
    }
}
