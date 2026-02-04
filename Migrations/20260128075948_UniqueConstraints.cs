using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies_EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UniqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_movies_MovieTitle_ReleaseYear",
                table: "movies",
                columns: new[] { "MovieTitle", "ReleaseYear" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GenreName",
                table: "Genres",
                column: "GenreName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_directors_Name",
                table: "directors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_actors_Name",
                table: "actors",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_movies_MovieTitle_ReleaseYear",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "IX_Genres_GenreName",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_directors_Name",
                table: "directors");

            migrationBuilder.DropIndex(
                name: "IX_actors_Name",
                table: "actors");
        }
    }
}
