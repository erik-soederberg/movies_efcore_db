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
            
            // Movie Title is required
            movie.Property(m => m.MovieTitle)
                .IsRequired()
                .HasMaxLength(100);
            
            // Movie release year is required and default value is set to year 2000
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
            
            // Actor name is required and max length is 100 letters
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
            
            // Director name is required and max length is 100 letters
            director.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);
            
            // Director age is required and default value is set to 1  
            director.Property(d => d.Age)
                .IsRequired()
                .HasDefaultValue(1);
        });
        
        /*
         * Genre
         */
        modelBuilder.Entity<Genre>(Genre =>
        {
            Genre.ToTable("genres");
            Genre.HasKey(g => g.GenreId);
            
            Genre.Property(g => g.GenreName)
                .IsRequired()
                .HasMaxLength(50);
        });

        /*
         * Movie + Actor => junction table 
         */
        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Actors)
            .WithMany(a => a.Movies)
            .UsingEntity(j => j.ToTable("movie_actors"));

        /*
         * Movie + Genre => junction table 
         */
        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Genres)
            .WithMany(g => g.Movies)
            .UsingEntity(j => j.ToTable("movie_genres"));
        
        
        /*
         * Movie Constraints 
         */
        modelBuilder.Entity<Movie>() 
            .HasIndex(m => new {m.MovieTitle, m.ReleaseYear})
            .IsUnique();
        
        /*
         * Actor Constraints 
         */
        modelBuilder.Entity<Actor>()
            .HasIndex(a => a.Name)
            .IsUnique();
        
        /*
         * Director constraints 
         */
        modelBuilder.Entity<Director>()
            .HasIndex(d => d.Name)
            .IsUnique();
        
        /*
         * Genre constraints 
         */
        modelBuilder.Entity<Genre>()
            .HasIndex(g => g.GenreName)
            .IsUnique();
    }


    
}

