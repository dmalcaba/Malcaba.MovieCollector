using Microsoft.EntityFrameworkCore.Migrations;

namespace Malcaba.MovieCollector.Data.Migrations.Sqlite
{
    public partial class AddTitleSort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TitleSort",
                table: "Movie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleSort",
                table: "Movie");
        }
    }
}
