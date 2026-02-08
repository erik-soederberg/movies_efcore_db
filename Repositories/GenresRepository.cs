using Microsoft.EntityFrameworkCore;
using Movies_EFCore.Data;
using Movies_EFCore.Domain.Repositories;
using Movies_EFCore.Entities;

namespace Movies_EFCore.Repositories;

public class GenresRepository : IGenresRepository
{
    public async Task<Genre> CreateGenreAsync(string name)
    {
        await using var db = new AppDbContext();
        
        var existingGenre = await db.Genres
            .AsNoTracking()
            .FirstOrDefaultAsync(g => g.GenreName == name);
        
        if (existingGenre != null)
            throw new InvalidOperationException("Genre already exists");
        
        var genre = new Genre { GenreName = name };

        db.Genres.Add(genre); 
        await db.SaveChangesAsync();

        return genre; 
    }

    public async Task<List<Genre>> ListAllGenresAsync()
    {
        await using var db = new AppDbContext();
        
        return await db.Genres
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task UpdateGenreAsync(int genreId, string newName)
    {
        await using var db = new AppDbContext();
        
        var genre = await db.Genres.FindAsync(genreId);

        if (genre == null)
            throw new InvalidOperationException("Genre not found");
        
        genre.GenreName = newName;
        await db.SaveChangesAsync();
    }

    public async Task DeleteGenreAsync(int genreId)
    {
        await using var db = new AppDbContext();

        var existingGenre = await db.Genres.FindAsync(genreId);

        if (existingGenre == null)
            throw new InvalidOperationException("Genre not found");
        
        db.Genres.Remove(existingGenre);
        await db.SaveChangesAsync();
    }
}