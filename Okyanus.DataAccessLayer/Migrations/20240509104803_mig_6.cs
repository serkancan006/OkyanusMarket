using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okyanus.DataAccessLayer.Migrations
{
    public partial class mig_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriUrunlers",
                table: "FavoriUrunlers");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "FavoriUrunlers",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0)
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "FavoriUrunlers",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "FavoriUrunlers",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "FavoriUrunlers",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriUrunlers",
                table: "FavoriUrunlers",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriUrunlers_ProductID",
                table: "FavoriUrunlers",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriUrunlers",
                table: "FavoriUrunlers");

            migrationBuilder.DropIndex(
                name: "IX_FavoriUrunlers_ProductID",
                table: "FavoriUrunlers");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "FavoriUrunlers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "FavoriUrunlers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "FavoriUrunlers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "FavoriUrunlers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriUrunlers",
                table: "FavoriUrunlers",
                columns: new[] { "ProductID", "AppUserID" });
        }
    }
}
