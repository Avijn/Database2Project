using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase2Project.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    style = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yeast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    malts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ibu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alcohol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    blg = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beers");
        }
    }
}
