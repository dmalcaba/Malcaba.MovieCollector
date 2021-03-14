using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Malcaba.MovieCollector.Data.Migrations.Sqlite
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Format",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Format", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Released = table.Column<DateTime>(nullable: false),
                    RunTime = table.Column<int>(nullable: false),
                    Plot = table.Column<string>(nullable: true),
                    FormatId = table.Column<int>(nullable: false),
                    RateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Format",
                        column: x => x.FormatId,
                        principalTable: "Format",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movie_Rate_RateId",
                        column: x => x.RateId,
                        principalTable: "Rate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_FormatId",
                table: "Movie",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_RateId",
                table: "Movie",
                column: "RateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Format");

            migrationBuilder.DropTable(
                name: "Rate");
        }
    }
}
