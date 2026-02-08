using Microsoft.EntityFrameworkCore;
using Movies_EFCore.Data;
using Movies_EFCore.Domain.Repositories;
using Movies_EFCore.Entities;
namespace Movies_EFCore.Repositories;

public class DirectorsRepository : IDirectorRepository
{
    public async Task<Director> CreateDirectorAsync(string name, int age)
    {
        await using var db = new AppDbContext();
        
        var existingDirector = await db.Directors
            .FirstOrDefaultAsync(d => d.Name == name);
        if (existingDirector != null)
        {
            throw new InvalidOperationException("Director already exists");
        }
        
        var director = new Director
        {
            Name = name,
            Age = age
        };
        
        await db.Directors.AddAsync(director);
        await db.SaveChangesAsync();
        
        return director;
        
    }
    
    public async Task<List<Director>> ListAllDirectorsAsync()
    {
        await using var db = new AppDbContext();
        
        return await db.Directors
            .AsNoTracking()
            .Include(d => d.Movies)
            .ToListAsync();

    }


    public async Task UpdateDirectorAsync(int directorId, string name, int age)
    {
        await using var db = new AppDbContext();
    
        var director = await db.Directors.FindAsync(directorId);
        if (director == null)
            throw new InvalidOperationException("Director not found");

        director.Name = name;
        director.Age = age;

        await db.SaveChangesAsync();
    }



    public async Task DeleteDirectorAsync(int directorId)
    {
        await using var db = new AppDbContext();

        var director = await db.Directors
            .FirstOrDefaultAsync(d => d.DirectorId == directorId);

        if (director == null)
        {
            Console.WriteLine("Director not found");
        }

        db.Directors.Remove(director);
        await db.SaveChangesAsync();
        
    }
    
}