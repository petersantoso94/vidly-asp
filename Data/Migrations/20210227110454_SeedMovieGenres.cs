using Microsoft.EntityFrameworkCore.Migrations;

namespace vidly.Migrations
{
    public partial class SeedMovieGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Genre", new[] { "Id", "Name" }, new object[] { 1, "Cartoon" });
            migrationBuilder.InsertData("Genre", new[] { "Id", "Name" }, new object[] { 2, "Action" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
