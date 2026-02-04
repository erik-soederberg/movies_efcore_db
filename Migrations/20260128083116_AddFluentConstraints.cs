using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies_EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddFluentConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movie_genres_Genres_GenresGenreId",
                table: "movie_genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "genres");

            migrationBuilder.RenameIndex(
                name: "IX_Genres_GenreName",
                table: "genres",
                newName: "IX_genres_GenreName");

            migrationBuilder.AlterColumn<int>(
                name: "ReleaseYear",
                table: "movies",
                type: "integer",
                nullable: false,
                defaultValue: 2000,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "directors",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "directors",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_genres",
                table: "genres",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_movie_genres_genres_GenresGenreId",
                table: "movie_genres",
                column: "GenresGenreId",
                principalTable: "genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movie_genres_genres_GenresGenreId",
                table: "movie_genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_genres",
                table: "genres");

            migrationBuilder.RenameTable(
                name: "genres",
                newName: "Genres");

            migrationBuilder.RenameIndex(
                name: "IX_genres_GenreName",
                table: "Genres",
                newName: "IX_Genres_GenreName");

            migrationBuilder.AlterColumn<int>(
                name: "ReleaseYear",
                table: "movies",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "directors",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "directors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_movie_genres_Genres_GenresGenreId",
                table: "movie_genres",
                column: "GenresGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
