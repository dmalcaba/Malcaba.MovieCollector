using Microsoft.EntityFrameworkCore.Migrations;

namespace Malcaba.MovieCollector.Data.Migrations.Sqlite
{
    public partial class UpdateMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Actors",
                table: "Movie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImdbID",
                table: "Movie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Poster",
                table: "Movie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actors",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ImdbID",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Poster",
                table: "Movie");
        }
    }
}
