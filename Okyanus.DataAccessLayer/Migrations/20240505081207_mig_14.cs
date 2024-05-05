using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okyanus.DataAccessLayer.Migrations
{
    public partial class mig_14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ssses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Status = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SssTitle = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SssContent = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ssses", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ssses");
        }
    }
}
