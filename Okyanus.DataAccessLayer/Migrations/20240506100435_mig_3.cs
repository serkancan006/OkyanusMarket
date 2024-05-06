using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okyanus.DataAccessLayer.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ANAGRUP",
                table: "Products",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "ALTGRUP3",
                table: "Products",
                type: "NVARCHAR2(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ALTGRUP2",
                table: "Products",
                type: "NVARCHAR2(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ALTGRUP1",
                table: "Products",
                type: "NVARCHAR2(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ANAGRUP_ALTGRUP1_ALTGRUP2_ALTGRUP3",
                table: "Products",
                columns: new[] { "ANAGRUP", "ALTGRUP1", "ALTGRUP2", "ALTGRUP3" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Groups_ANAGRUP_ALTGRUP1_ALTGRUP2_ALTGRUP3",
                table: "Products",
                columns: new[] { "ANAGRUP", "ALTGRUP1", "ALTGRUP2", "ALTGRUP3" },
                principalTable: "Groups",
                principalColumns: new[] { "ANAGRUP", "ALTGRUP1", "ALTGRUP2", "ALTGRUP3" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Groups_ANAGRUP_ALTGRUP1_ALTGRUP2_ALTGRUP3",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ANAGRUP_ALTGRUP1_ALTGRUP2_ALTGRUP3",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "ANAGRUP",
                table: "Products",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ALTGRUP3",
                table: "Products",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ALTGRUP2",
                table: "Products",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ALTGRUP1",
                table: "Products",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");
        }
    }
}
