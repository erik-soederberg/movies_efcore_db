using Microsoft.EntityFrameworkCore;
using Movies_EFCore.Entities;

namespace Movies_EFCore.Data;

public class AppDbContext : DbContext
{
    // Entiteter
    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<Actor> Actors { get; set; } = null!;
    public DbSet<Director> Directors { get; set; } = null!;

    public DbSet<Genre> Genres { get; set; } = null!;
    
    public DbSet<MovieActor> MovieActors { get; set; } = null!;



    // Konfigurera databasanslutning
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // PostgreSQL-anslutning
        optionsBuilder.UseNpgsql("Host=localhost;Database=movies_db;Username=postgres;Password=2860");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
         * Movie
         */
        modelBuilder.Entity<Movie>(movie =>
        {
            movie.ToTable("movies");
            movie.HasKey(m => m.MovieId);

            movie.HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId)
                .IsRequired();

            movie.Property(m => m.MovieTitle)
                .IsRequired()
                .HasMaxLength(100);

            movie.Property(m => m.ReleaseYear)
                .IsRequired()
                .HasDefaultValue(2000);
        });

        /*
         * Actor
         */
        modelBuilder.Entity<Actor>(actor =>
        {
            actor.ToTable("actors");
            actor.HasKey(a => a.ActorId);

            actor.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        /*
         * Director
         */
        modelBuilder.Entity<Director>(director =>
        {
            director.ToTable("directors");
            director.HasKey(d => d.DirectorId);

            director.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            director.Property(d => d.Age)
                .IsRequired()
                .HasDefaultValue(1);
        });

        /*
         * Genre
         */
        modelBuilder.Entity<Genre>(genre =>
        {
            genre.ToTable("genres");
            genre.HasKey(g => g.GenreId);

            genre.Property(g => g.GenreName)
                .IsRequired()
                .HasMaxLength(50);
        });
        
        /*
         * MovieActor
         */
        
        modelBuilder.Entity<MovieActor>()
            .HasKey(ma => new { ma.MovieId, ma.ActorId });

        
        /*
         * Constraints
         */
        modelBuilder.Entity<Movie>().HasIndex(m => new { m.MovieTitle, m.ReleaseYear }).IsUnique();
        modelBuilder.Entity<Actor>().HasIndex(a => a.Name).IsUnique();
        modelBuilder.Entity<Director>().HasIndex(d => d.Name).IsUnique();
        modelBuilder.Entity<Genre>().HasIndex(g => g.GenreName).IsUnique();

        /*
         * SEED DATA
         */
        modelBuilder.Entity<Director>().HasData(
            new Director { DirectorId = 1, Name = "Christopher Nolan", Age = 52 },
            new Director { DirectorId = 2, Name = "Steven Spielberg", Age = 76 },
            new Director { DirectorId = 3, Name = "Quentin Tarantino", Age = 60 },
            new Director { DirectorId = 4, Name = "Martin Scorsese", Age = 79 },
            new Director { DirectorId = 5, Name = "James Cameron", Age = 68 },
            new Director { DirectorId = 6, Name = "Ridley Scott", Age = 85 },
            new Director { DirectorId = 7, Name = "Peter Jackson", Age = 60 },
            new Director { DirectorId = 8, Name = "Tim Burton", Age = 64 },
            new Director { DirectorId = 9, Name = "Clint Eastwood", Age = 92 },
            new Director { DirectorId = 10, Name = "David Fincher", Age = 60 },
            new Director { DirectorId = 11, Name = "Guy Ritchie", Age = 53 },
            new Director { DirectorId = 12, Name = "Sofia Coppola", Age = 52 },
            new Director { DirectorId = 13, Name = "Wes Anderson", Age = 54 },
            new Director { DirectorId = 14, Name = "Guillermo del Toro", Age = 59 },
            new Director { DirectorId = 15, Name = "Denis Villeneuve", Age = 52 },
            new Director { DirectorId = 16, Name = "Alfonso Cuarón", Age = 60 },
            new Director { DirectorId = 17, Name = "Spike Lee", Age = 67 },
            new Director { DirectorId = 18, Name = "Taika Waititi", Age = 46 },
            new Director { DirectorId = 19, Name = "Jordan Peele", Age = 44 },
            new Director { DirectorId = 20, Name = "Baz Luhrmann", Age = 57 },
            new Director { DirectorId = 21, Name = "J.J. Abrams", Age = 57 },
            new Director { DirectorId = 22, Name = "Ron Howard", Age = 69 },
            new Director { DirectorId = 23, Name = "Michael Bay", Age = 58 },
            new Director { DirectorId = 24, Name = "Francis Ford Coppola", Age = 83 },
            new Director { DirectorId = 25, Name = "Ang Lee", Age = 67 },
            new Director { DirectorId = 26, Name = "Robert Zemeckis", Age = 68 },
            new Director { DirectorId = 27, Name = "Patty Jenkins", Age = 50 },
            new Director { DirectorId = 28, Name = "M. Night Shyamalan", Age = 52 },
            new Director { DirectorId = 29, Name = "Greta Gerwig", Age = 40 },
            new Director { DirectorId = 30, Name = "Christopher McQuarrie", Age = 55 }
        );

        modelBuilder.Entity<Genre>().HasData(
            new Genre { GenreId = 1, GenreName = "Action" },
            new Genre { GenreId = 2, GenreName = "Adventure" },
            new Genre { GenreId = 3, GenreName = "Comedy" },
            new Genre { GenreId = 4, GenreName = "Drama" },
            new Genre { GenreId = 5, GenreName = "Thriller" },
            new Genre { GenreId = 6, GenreName = "Horror" },
            new Genre { GenreId = 7, GenreName = "Sci-Fi" },
            new Genre { GenreId = 8, GenreName = "Romance" },
            new Genre { GenreId = 9, GenreName = "Fantasy" },
            new Genre { GenreId = 10, GenreName = "Crime" },
            new Genre { GenreId = 11, GenreName = "Mystery" },
            new Genre { GenreId = 12, GenreName = "Animation" },
            new Genre { GenreId = 13, GenreName = "Musical" },
            new Genre { GenreId = 14, GenreName = "Biography" },
            new Genre { GenreId = 15, GenreName = "War" },
            new Genre { GenreId = 16, GenreName = "Family" },
            new Genre { GenreId = 17, GenreName = "History" },
            new Genre { GenreId = 18, GenreName = "Sport" },
            new Genre { GenreId = 19, GenreName = "Western" },
            new Genre { GenreId = 20, GenreName = "Documentary" },
            new Genre { GenreId = 21, GenreName = "Musical Comedy" },
            new Genre { GenreId = 22, GenreName = "Psychological Thriller" },
            new Genre { GenreId = 23, GenreName = "Political Drama" },
            new Genre { GenreId = 24, GenreName = "Romantic Comedy" },
            new Genre { GenreId = 25, GenreName = "Epic" },
            new Genre { GenreId = 26, GenreName = "Satire" },
            new Genre { GenreId = 27, GenreName = "Cyberpunk" },
            new Genre { GenreId = 28, GenreName = "Dark Fantasy" },
            new Genre { GenreId = 29, GenreName = "Superhero" },
            new Genre { GenreId = 30, GenreName = "Adventure Comedy" }
        );

        modelBuilder.Entity<Actor>().HasData(
            new Actor { ActorId = 1, Name = "Leonardo DiCaprio", Age = 48 },
            new Actor { ActorId = 2, Name = "Brad Pitt", Age = 59 },
            new Actor { ActorId = 3, Name = "Morgan Freeman", Age = 85 },
            new Actor { ActorId = 4, Name = "Scarlett Johansson", Age = 38 },
            new Actor { ActorId = 5, Name = "Tom Hanks", Age = 66 },
            new Actor { ActorId = 6, Name = "Meryl Streep", Age = 73 },
            new Actor { ActorId = 7, Name = "Johnny Depp", Age = 60 },
            new Actor { ActorId = 8, Name = "Angelina Jolie", Age = 47 },
            new Actor { ActorId = 9, Name = "Robert Downey Jr.", Age = 58 },
            new Actor { ActorId = 10, Name = "Chris Hemsworth", Age = 39 },
            new Actor { ActorId = 11, Name = "Chris Evans", Age = 42 },
            new Actor { ActorId = 12, Name = "Chris Pratt", Age = 44 },
            new Actor { ActorId = 13, Name = "Anne Hathaway", Age = 40 },
            new Actor { ActorId = 14, Name = "Emma Stone", Age = 34 },
            new Actor { ActorId = 15, Name = "Ryan Gosling", Age = 42 },
            new Actor { ActorId = 16, Name = "Matt Damon", Age = 52 },
            new Actor { ActorId = 17, Name = "Hugh Jackman", Age = 53 },
            new Actor { ActorId = 18, Name = "Natalie Portman", Age = 41 },
            new Actor { ActorId = 19, Name = "Keanu Reeves", Age = 57 },
            new Actor { ActorId = 20, Name = "Dwayne Johnson", Age = 51 },
            new Actor { ActorId = 21, Name = "Gal Gadot", Age = 37 },
            new Actor { ActorId = 22, Name = "Zendaya", Age = 26 },
            new Actor { ActorId = 23, Name = "Will Smith", Age = 55 },
            new Actor { ActorId = 24, Name = "Chris Pine", Age = 43 },
            new Actor { ActorId = 25, Name = "Jennifer Lawrence", Age = 32 },
            new Actor { ActorId = 26, Name = "Margot Robbie", Age = 33 },
            new Actor { ActorId = 27, Name = "Tom Hardy", Age = 45 },
            new Actor { ActorId = 28, Name = "Galileo Galilei", Age = 77 },
            new Actor { ActorId = 29, Name = "Cate Blanchett", Age = 53 },
            new Actor { ActorId = 30, Name = "Daniel Day-Lewis", Age = 65 }
        );

        modelBuilder.Entity<Movie>().HasData(
            new Movie { MovieId = 1, MovieTitle = "Inception", ReleaseYear = 2010, DirectorId = 1 },
            new Movie { MovieId = 2, MovieTitle = "Interstellar", ReleaseYear = 2014, DirectorId = 1 },
            new Movie { MovieId = 3, MovieTitle = "Jurassic Park", ReleaseYear = 1993, DirectorId = 2 },
            new Movie { MovieId = 4, MovieTitle = "E.T.", ReleaseYear = 1982, DirectorId = 2 },
            new Movie { MovieId = 5, MovieTitle = "Pulp Fiction", ReleaseYear = 1994, DirectorId = 3 },
            new Movie { MovieId = 6, MovieTitle = "Django Unchained", ReleaseYear = 2012, DirectorId = 3 },
            new Movie { MovieId = 7, MovieTitle = "The Wolf of Wall Street", ReleaseYear = 2013, DirectorId = 4 },
            new Movie { MovieId = 8, MovieTitle = "Titanic", ReleaseYear = 1997, DirectorId = 5 },
            new Movie { MovieId = 9, MovieTitle = "Gladiator", ReleaseYear = 2000, DirectorId = 6 },
            new Movie { MovieId = 10, MovieTitle = "The Lord of the Rings", ReleaseYear = 2001, DirectorId = 7 },
            new Movie { MovieId = 11, MovieTitle = "Alice in Wonderland", ReleaseYear = 2010, DirectorId = 8 },
            new Movie { MovieId = 12, MovieTitle = "Gran Torino", ReleaseYear = 2008, DirectorId = 9 },
            new Movie { MovieId = 13, MovieTitle = "Fight Club", ReleaseYear = 1999, DirectorId = 10 },
            new Movie { MovieId = 14, MovieTitle = "Sherlock Holmes", ReleaseYear = 2009, DirectorId = 11 },
            new Movie { MovieId = 15, MovieTitle = "Lost in Translation", ReleaseYear = 2003, DirectorId = 12 },
            new Movie { MovieId = 16, MovieTitle = "The Grand Budapest Hotel", ReleaseYear = 2014, DirectorId = 13 },
            new Movie { MovieId = 17, MovieTitle = "Pan's Labyrinth", ReleaseYear = 2006, DirectorId = 14 },
            new Movie { MovieId = 18, MovieTitle = "Arrival", ReleaseYear = 2016, DirectorId = 15 },
            new Movie { MovieId = 19, MovieTitle = "Gravity", ReleaseYear = 2013, DirectorId = 16 },
            new Movie { MovieId = 20, MovieTitle = "BlackKklansman", ReleaseYear = 2018, DirectorId = 17 },
            new Movie { MovieId = 21, MovieTitle = "Jojo Rabbit", ReleaseYear = 2019, DirectorId = 18 },
            new Movie { MovieId = 22, MovieTitle = "Get Out", ReleaseYear = 2017, DirectorId = 19 },
            new Movie { MovieId = 23, MovieTitle = "Moulin Rouge!", ReleaseYear = 2001, DirectorId = 20 },
            new Movie
            {
                MovieId = 24, MovieTitle = "Star Wars: The Force Awakens", ReleaseYear = 2015, DirectorId = 21
            },
            new Movie { MovieId = 25, MovieTitle = "A Beautiful Mind", ReleaseYear = 2001, DirectorId = 22 },
            new Movie { MovieId = 26, MovieTitle = "Transformers", ReleaseYear = 2007, DirectorId = 23 },
            new Movie { MovieId = 27, MovieTitle = "The Godfather", ReleaseYear = 1972, DirectorId = 24 },
            new Movie { MovieId = 28, MovieTitle = "Life of Pi", ReleaseYear = 2012, DirectorId = 25 },
            new Movie { MovieId = 29, MovieTitle = "Forrest Gump", ReleaseYear = 1994, DirectorId = 26 },
            new Movie { MovieId = 30, MovieTitle = "Wonder Woman", ReleaseYear = 2017, DirectorId = 27 }
        );
        
        modelBuilder.Entity<MovieActor>().HasData(
            new MovieActor { MovieId = 1, ActorId = 1 }, // Inception - Leonardo DiCaprio
            new MovieActor { MovieId = 1, ActorId = 2 }, // Inception - Brad Pitt
            new MovieActor { MovieId = 2, ActorId = 1 }, // Interstellar - Leonardo DiCaprio
            new MovieActor { MovieId = 3, ActorId = 5 }, // Jurassic Park - Tom Hanks
            new MovieActor { MovieId = 4, ActorId = 5 }, // E.T. - Tom Hanks
            new MovieActor { MovieId = 5, ActorId = 2 }, // Pulp Fiction - Brad Pitt
            new MovieActor { MovieId = 5, ActorId = 3 }, // Pulp Fiction - Morgan Freeman
            new MovieActor { MovieId = 6, ActorId = 2 }, // Django Unchained - Brad Pitt
            new MovieActor { MovieId = 7, ActorId = 1 }, // The Wolf of Wall Street - Leonardo DiCaprio
            new MovieActor { MovieId = 8, ActorId = 1 }, // Titanic - Leonardo DiCaprio
            new MovieActor { MovieId = 8, ActorId = 4 }, // Titanic - Scarlett Johansson
            new MovieActor { MovieId = 9, ActorId = 16 }, // Gladiator - Matt Damon
            new MovieActor { MovieId = 10, ActorId = 10 }, // LOTR - Chris Hemsworth
            new MovieActor { MovieId = 10, ActorId = 12 }, // LOTR - Chris Pratt
            new MovieActor { MovieId = 11, ActorId = 7 }, // Alice in Wonderland - Johnny Depp
            new MovieActor { MovieId = 12, ActorId = 5 }, // Gran Torino - Tom Hanks
            new MovieActor { MovieId = 13, ActorId = 2 }, // Fight Club - Brad Pitt
            new MovieActor { MovieId = 13, ActorId = 16 } // Fight Club - Matt Damon
        );

        
    }
}
