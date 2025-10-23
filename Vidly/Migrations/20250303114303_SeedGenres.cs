using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class SeedGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genres (Name) Values ('Comedy')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) Values ('Horror')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) Values ('Thriller')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) Values ('Musical')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) Values ('Drama')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
