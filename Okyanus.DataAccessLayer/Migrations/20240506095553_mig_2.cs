using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okyanus.DataAccessLayer.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Groups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                columns: new[] { "ANAGRUP", "ALTGRUP1", "ALTGRUP2", "ALTGRUP3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Groups",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0)
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Groups",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Groups",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Groups",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "ID");
        }
    }
}
