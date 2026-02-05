using Microsoft.EntityFrameworkCore;
using Movies_EFCore.Data;
using Movies_EFCore.Domain.DTOs;
using Movies_EFCore.Domain.Repositories;
using Movies_EFCore.Entities;

namespace Movies_EFCore.Repositories;

public class MoviesRepository : IMoviesRepository
{
    public async Task<Movie> CreateMovieAsync(
        string title, 
        int year, 
        List<string> actorNames,
        string directorName,
        List<string> genreNames)
    {
        
        await using var db = new AppDbContext();

        var existingMovie = await db.Movies
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.MovieTitle == title && m.ReleaseYear == year);
        if (existingMovie != null)
            throw new InvalidOperationException("Movie already exists");
        
        
        var existingDirector = await db.Directors
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Name == directorName);
        if (existingDirector != null)
        {
            throw new InvalidOperationException("Director already exists");
        }

        var genres = new List<Genre>();
        foreach (var genreName in genreNames)
        {
            var existingGenre = await db.Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.GenreName == genreName);

            genres.Add(existingGenre ?? new Genre { GenreName = genreName });
        }
        Director director = existingDirector ?? new Director { Name = directorName };
        

        var newMovie = new Movie
        {
            MovieTitle = title,
            ReleaseYear = year,
            Actors = actorNames.Select(name => new Actor { Name = name }).ToList(),
            Director = director,
            Genres = genres
        };
        
        db.Movies.Add(newMovie);
        await db.SaveChangesAsync();

        return newMovie;
    }
    

    public async Task<List<Movie>> ListAllMoviesAsync()
    {

        await using var db = new AppDbContext();
        
        return await db.Movies
            .AsNoTracking()
            .Include(m => m.Actors)
            .ToListAsync();
    }


    public async Task<List<Movie>> DeleteMovieAsync(int movieId)
    {
        await using var db = new AppDbContext();

        var existingMovie = await db.Movies.FindAsync(movieId);

        if (existingMovie == null)
        {
            throw new InvalidOperationException("Movie not found");
        }
        
        db.Movies.Remove(existingMovie);
        await db.SaveChangesAsync();

        return await db.Movies.ToListAsync();
    }
    
    


    public async Task<List<Movie>> UpdateMovieAsync(
        int movieId,
        string title,
        int year,
        List<string> actorNames,
        string directorName,
        List<string> genreNames)
    {
        await using var db = new AppDbContext();

        var movie = await db.Movies
            .AsNoTracking()
            .Include(m => m.Actors)
            .Include(m => m.Genres)
            .Include(m => m.Director)
            .FirstOrDefaultAsync(m => m.MovieId == movieId);

        if (movie == null)
            throw new InvalidOperationException("Movie was not found");

        movie.MovieTitle = title;
        movie.ReleaseYear = year;
        
        var existingDirector = await db.Directors.FirstOrDefaultAsync(d => d.Name == directorName);
        movie.Director = existingDirector ?? new Director { Name = directorName };
        
        var genres = new List<Genre>();
        foreach (var genreName in genreNames)
        {
            var existingGenre = await db.Genres.FirstOrDefaultAsync(g => g.GenreName == genreName);
            genres.Add(existingGenre ?? new Genre { GenreName = genreName });
        }
        movie.Genres = genres;
        
        var actors = new List<Actor>();
        foreach (var actorName in actorNames)
        {
            var existingActor = await db.Actors.FirstOrDefaultAsync(a => a.Name == actorName);
            actors.Add(existingActor ?? new Actor { Name = actorName });
        }
        movie.Actors = actors;

        await db.SaveChangesAsync();

        return await ListAllMoviesAsync();
    }






    public async Task AddActorToMovieAsync(int movieId, int actorId)
    {
        await using var db = new AppDbContext();

        var movie = await db.Movies
            .AsNoTracking()
            .Include(m => m.Actors)
            .FirstOrDefaultAsync(m => m.MovieId == movieId);

        var actor = await db.Actors
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.ActorId == actorId);

        if (movie == null || actor == null)
        {
            throw new InvalidOperationException("Movie or actor not found");
        }
        
        if (!movie.Actors.Any(a => a.ActorId == actor.ActorId))
        {
            movie.Actors.Add(actor);
            await db.SaveChangesAsync();
        }


    }

    public async Task RemoveActorFromMovieAsync(int movieId, int actorId)
    {

        await using var db = new AppDbContext(); 
        
        var movie = await db.Movies
            .AsNoTracking()
            .Include(m => m.Actors)
            .FirstOrDefaultAsync(m => m.MovieId == movieId);
        
        var actor = await db.Actors
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.ActorId == actorId);
        
        if (movie == null || actor == null)
        {
            throw new InvalidOperationException("Movie or actor not found");
        }
        
        movie.Actors.Remove(actor);
        await db.SaveChangesAsync();
    }

    public async Task<List<MovieReleaseSummary>> FetchReleaseSummariesAsync()
    {
        await using var db = new AppDbContext();

        return await db.Movies
            .AsNoTracking()
            .Select(m => new MovieReleaseSummary
            {
                Title = m.MovieTitle,
                Year = m.ReleaseYear,
                Director = m.Director.Name
            })
            .OrderBy(m => m.Year)
            .ToListAsync();
    
    }
                
    
}