using Microsoft.EntityFrameworkCore;
using Movies_EFCore.Data;
using Movies_EFCore.Domain.Repositories;
using Movies_EFCore.Entities;

namespace Movies_EFCore.Repositories;

public class ActorsRepository : IActorsRepository
{
    public async Task<Actor> CreateActorAsync(string name, int age)
    {
        await using var db = new AppDbContext();
        
        var existingActor = await db.Actors
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Name == name);
        if (existingActor != null)
            throw new InvalidOperationException("Actor already exists");

        var actor = new Actor
        {
            Name = name,
            Age = age
        };

        db.Actors.Add(actor);
        
        await db.SaveChangesAsync();
        
        return actor;
    }

    public async Task<Actor> DeleteActorAsync(int actorId)
    {
        await using var db = new AppDbContext();
        
        var existingActor = await db.Actors.FindAsync(actorId);

        if (existingActor == null)
        {
            Console.WriteLine("Actor not found");
        }
        
        Console.WriteLine($"Are you sure you want to delete director {existingActor?.Name}? (y/n)");
        var confirm = Console.ReadLine()?.ToLower();
        
        if (confirm != "y")
        {
            Console.WriteLine("Delete cancelled.");
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        if (existingActor != null)
        {
            db.Actors.Remove(existingActor);
            await db.SaveChangesAsync();
            Console.WriteLine("Actor deleted");
        }
        
        return existingActor;
    }

    public async Task<List<Actor>> ListAllActorsAsync()
    {
        
        await using var db = new AppDbContext();
        
        return await db.Actors
            .AsNoTracking()
            .ToListAsync();
        
    }

    public async Task<List<Actor>> UpdateActorAsync(
        int actorId,
        string newName,
        int newAge)
    {
        await using var db = new AppDbContext();
        
        var actor = await db.Actors.FindAsync(actorId);

        if (actor == null)
        {
            throw new InvalidOperationException("Actor not found");
        }
        
        actor.Name = newName;
        actor.Age = newAge;
        
        await db.SaveChangesAsync();
        
        return await UpdateActorAsync(actorId, newName, newAge);
        
    }
    
    public async Task<List<Actor>> GetActorsWithMoviesAsync()
    {
        using var db = new AppDbContext();

        return await db.Actors
            .AsNoTracking()                
            .Include(a => a.Movies)         
            .ToListAsync();
    }



}