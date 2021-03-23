using Microsoft.EntityFrameworkCore.Migrations;

namespace Malcaba.MovieCollector.Data.Migrations.Sqlite
{
    public partial class AddMovieCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Collection",
                table: "Movie",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Dolby",
                table: "Movie",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FullScreen",
                table: "Movie",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Movie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Collection",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Dolby",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "FullScreen",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movie");
        }
    }
}
