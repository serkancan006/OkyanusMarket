using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okyanus.DataAccessLayer.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Orders",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserAdreses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserAdress = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UserApartman = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UserDaire = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UserKat = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UserSehir = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UserIlce = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AppUserID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Status = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdreses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserAdreses_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserID",
                table: "Orders",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdreses_AppUserID",
                table: "UserAdreses",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AppUserID",
                table: "Orders",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AppUserID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "UserAdreses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AppUserID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Orders");
        }
    }
}
