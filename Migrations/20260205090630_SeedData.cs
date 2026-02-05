using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies_EFCore.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movie_actors_actors_ActorsActorId",
                table: "movie_actors");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_actors_movies_MoviesMovieId",
                table: "movie_actors");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_genres_genres_GenresGenreId",
                table: "movie_genres");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_genres_movies_MoviesMovieId",
                table: "movie_genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movie_genres",
                table: "movie_genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movie_actors",
                table: "movie_actors");

            migrationBuilder.RenameTable(
                name: "movie_genres",
                newName: "GenreMovie");

            migrationBuilder.RenameTable(
                name: "movie_actors",
                newName: "ActorMovie");

            migrationBuilder.RenameIndex(
                name: "IX_movie_genres_MoviesMovieId",
                table: "GenreMovie",
                newName: "IX_GenreMovie_MoviesMovieId");

            migrationBuilder.RenameIndex(
                name: "IX_movie_actors_MoviesMovieId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_MoviesMovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreMovie",
                table: "GenreMovie",
                columns: new[] { "GenresGenreId", "MoviesMovieId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorMovie",
                table: "ActorMovie",
                columns: new[] { "ActorsActorId", "MoviesMovieId" });

            migrationBuilder.InsertData(
                table: "actors",
                columns: new[] { "ActorId", "Age", "Name" },
                values: new object[,]
                {
                    { 1, 48, "Leonardo DiCaprio" },
                    { 2, 59, "Brad Pitt" },
                    { 3, 85, "Morgan Freeman" },
                    { 4, 38, "Scarlett Johansson" },
                    { 5, 66, "Tom Hanks" },
                    { 6, 73, "Meryl Streep" },
                    { 7, 60, "Johnny Depp" },
                    { 8, 47, "Angelina Jolie" },
                    { 9, 58, "Robert Downey Jr." },
                    { 10, 39, "Chris Hemsworth" },
                    { 11, 42, "Chris Evans" },
                    { 12, 44, "Chris Pratt" },
                    { 13, 40, "Anne Hathaway" },
                    { 14, 34, "Emma Stone" },
                    { 15, 42, "Ryan Gosling" },
                    { 16, 52, "Matt Damon" },
                    { 17, 53, "Hugh Jackman" },
                    { 18, 41, "Natalie Portman" },
                    { 19, 57, "Keanu Reeves" },
                    { 20, 51, "Dwayne Johnson" },
                    { 21, 37, "Gal Gadot" },
                    { 22, 26, "Zendaya" },
                    { 23, 55, "Will Smith" },
                    { 24, 43, "Chris Pine" },
                    { 25, 32, "Jennifer Lawrence" },
                    { 26, 33, "Margot Robbie" },
                    { 27, 45, "Tom Hardy" },
                    { 28, 77, "Galileo Galilei" },
                    { 29, 53, "Cate Blanchett" },
                    { 30, 65, "Daniel Day-Lewis" }
                });

            migrationBuilder.InsertData(
                table: "directors",
                columns: new[] { "DirectorId", "Age", "Name" },
                values: new object[,]
                {
                    { 1, 52, "Christopher Nolan" },
                    { 2, 76, "Steven Spielberg" },
                    { 3, 60, "Quentin Tarantino" },
                    { 4, 79, "Martin Scorsese" },
                    { 5, 68, "James Cameron" },
                    { 6, 85, "Ridley Scott" },
                    { 7, 60, "Peter Jackson" },
                    { 8, 64, "Tim Burton" },
                    { 9, 92, "Clint Eastwood" },
                    { 10, 60, "David Fincher" },
                    { 11, 53, "Guy Ritchie" },
                    { 12, 52, "Sofia Coppola" },
                    { 13, 54, "Wes Anderson" },
                    { 14, 59, "Guillermo del Toro" },
                    { 15, 52, "Denis Villeneuve" },
                    { 16, 60, "Alfonso Cuarón" },
                    { 17, 67, "Spike Lee" },
                    { 18, 46, "Taika Waititi" },
                    { 19, 44, "Jordan Peele" },
                    { 20, 57, "Baz Luhrmann" },
                    { 21, 57, "J.J. Abrams" },
                    { 22, 69, "Ron Howard" },
                    { 23, 58, "Michael Bay" },
                    { 24, 83, "Francis Ford Coppola" },
                    { 25, 67, "Ang Lee" },
                    { 26, 68, "Robert Zemeckis" },
                    { 27, 50, "Patty Jenkins" },
                    { 28, 52, "M. Night Shyamalan" },
                    { 29, 40, "Greta Gerwig" },
                    { 30, 55, "Christopher McQuarrie" }
                });

            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Comedy" },
                    { 4, "Drama" },
                    { 5, "Thriller" },
                    { 6, "Horror" },
                    { 7, "Sci-Fi" },
                    { 8, "Romance" },
                    { 9, "Fantasy" },
                    { 10, "Crime" },
                    { 11, "Mystery" },
                    { 12, "Animation" },
                    { 13, "Musical" },
                    { 14, "Biography" },
                    { 15, "War" },
                    { 16, "Family" },
                    { 17, "History" },
                    { 18, "Sport" },
                    { 19, "Western" },
                    { 20, "Documentary" },
                    { 21, "Musical Comedy" },
                    { 22, "Psychological Thriller" },
                    { 23, "Political Drama" },
                    { 24, "Romantic Comedy" },
                    { 25, "Epic" },
                    { 26, "Satire" },
                    { 27, "Cyberpunk" },
                    { 28, "Dark Fantasy" },
                    { 29, "Superhero" },
                    { 30, "Adventure Comedy" }
                });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieId", "DirectorId", "MovieTitle", "ReleaseYear" },
                values: new object[,]
                {
                    { 1, 1, "Inception", 2010 },
                    { 2, 1, "Interstellar", 2014 },
                    { 3, 2, "Jurassic Park", 1993 },
                    { 4, 2, "E.T.", 1982 },
                    { 5, 3, "Pulp Fiction", 1994 },
                    { 6, 3, "Django Unchained", 2012 },
                    { 7, 4, "The Wolf of Wall Street", 2013 },
                    { 8, 5, "Titanic", 1997 },
                    { 9, 6, "Gladiator", 2000 },
                    { 10, 7, "The Lord of the Rings", 2001 },
                    { 11, 8, "Alice in Wonderland", 2010 },
                    { 12, 9, "Gran Torino", 2008 },
                    { 13, 10, "Fight Club", 1999 },
                    { 14, 11, "Sherlock Holmes", 2009 },
                    { 15, 12, "Lost in Translation", 2003 },
                    { 16, 13, "The Grand Budapest Hotel", 2014 },
                    { 17, 14, "Pan's Labyrinth", 2006 },
                    { 18, 15, "Arrival", 2016 },
                    { 19, 16, "Gravity", 2013 },
                    { 20, 17, "BlackKklansman", 2018 },
                    { 21, 18, "Jojo Rabbit", 2019 },
                    { 22, 19, "Get Out", 2017 },
                    { 23, 20, "Moulin Rouge!", 2001 },
                    { 24, 21, "Star Wars: The Force Awakens", 2015 },
                    { 25, 22, "A Beautiful Mind", 2001 },
                    { 26, 23, "Transformers", 2007 },
                    { 27, 24, "The Godfather", 1972 },
                    { 28, 25, "Life of Pi", 2012 },
                    { 29, 26, "Forrest Gump", 1994 },
                    { 30, 27, "Wonder Woman", 2017 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_actors_ActorsActorId",
                table: "ActorMovie",
                column: "ActorsActorId",
                principalTable: "actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_movies_MoviesMovieId",
                table: "ActorMovie",
                column: "MoviesMovieId",
                principalTable: "movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_genres_GenresGenreId",
                table: "GenreMovie",
                column: "GenresGenreId",
                principalTable: "genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_movies_MoviesMovieId",
                table: "GenreMovie",
                column: "MoviesMovieId",
                principalTable: "movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_actors_ActorsActorId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_movies_MoviesMovieId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_genres_GenresGenreId",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_movies_MoviesMovieId",
                table: "GenreMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreMovie",
                table: "GenreMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorMovie",
                table: "ActorMovie");

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "ActorId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "directors",
                keyColumn: "DirectorId",
                keyValue: 27);

            migrationBuilder.RenameTable(
                name: "GenreMovie",
                newName: "movie_genres");

            migrationBuilder.RenameTable(
                name: "ActorMovie",
                newName: "movie_actors");

            migrationBuilder.RenameIndex(
                name: "IX_GenreMovie_MoviesMovieId",
                table: "movie_genres",
                newName: "IX_movie_genres_MoviesMovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_MoviesMovieId",
                table: "movie_actors",
                newName: "IX_movie_actors_MoviesMovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movie_genres",
                table: "movie_genres",
                columns: new[] { "GenresGenreId", "MoviesMovieId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_movie_actors",
                table: "movie_actors",
                columns: new[] { "ActorsActorId", "MoviesMovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_movie_actors_actors_ActorsActorId",
                table: "movie_actors",
                column: "ActorsActorId",
                principalTable: "actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_actors_movies_MoviesMovieId",
                table: "movie_actors",
                column: "MoviesMovieId",
                principalTable: "movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_genres_genres_GenresGenreId",
                table: "movie_genres",
                column: "GenresGenreId",
                principalTable: "genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_genres_movies_MoviesMovieId",
                table: "movie_genres",
                column: "MoviesMovieId",
                principalTable: "movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
