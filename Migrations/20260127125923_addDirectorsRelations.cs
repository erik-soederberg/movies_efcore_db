using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies_EFCore.Migrations
{
    /// <inheritdoc />
    public partial class addDirectorsRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movie_genres_Genre_GenresGenreId",
                table: "movie_genres");

            migrationBuilder.DropForeignKey(
                name: "FK_movies_Director_DirectorId",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Director",
                table: "Director");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "Director",
                newName: "directors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_directors",
                table: "directors",
                column: "DirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_movie_genres_Genres_GenresGenreId",
                table: "movie_genres",
                column: "GenresGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movies_directors_DirectorId",
                table: "movies",
                column: "DirectorId",
                principalTable: "directors",
                principalColumn: "DirectorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movie_genres_Genres_GenresGenreId",
                table: "movie_genres");

            migrationBuilder.DropForeignKey(
                name: "FK_movies_directors_DirectorId",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_directors",
                table: "directors");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameTable(
                name: "directors",
                newName: "Director");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Director",
                table: "Director",
                column: "DirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_movie_genres_Genre_GenresGenreId",
                table: "movie_genres",
                column: "GenresGenreId",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movies_Director_DirectorId",
                table: "movies",
                column: "DirectorId",
                principalTable: "Director",
                principalColumn: "DirectorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
