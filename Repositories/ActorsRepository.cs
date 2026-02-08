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

    public async Task DeleteActorAsync(int actorId)
    {
        await using var db = new AppDbContext();

        var existingActor = await db.Actors.FindAsync(actorId);

        if (existingActor == null)
            throw new InvalidOperationException("Actor not found");

        db.Actors.Remove(existingActor);
        await db.SaveChangesAsync();
    }


    public async Task<List<Actor>> ListAllActorsAsync()
    {
        
        await using var db = new AppDbContext();
        
        return await db.Actors
            .AsNoTracking()
            .ToListAsync();
        
    }

    public async Task UpdateActorAsync(int actorId, string newName, int newAge)
    {
        await using var db = new AppDbContext();
    
        var actor = await db.Actors.FindAsync(actorId);

        if (actor == null)
            throw new InvalidOperationException("Actor not found");
    
        actor.Name = newName;
        actor.Age = newAge;
    
        await db.SaveChangesAsync();
    }

    
    public async Task<List<Actor>> GetActorsWithMoviesAsync()
    {
        await using var db = new AppDbContext();

        return await db.Actors
            .AsNoTracking()                
            .Include(a => a.Movies)         
            .ToListAsync();
    }



}