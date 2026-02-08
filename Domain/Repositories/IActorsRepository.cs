using Movies_EFCore.Entities;

namespace Movies_EFCore.Domain.Repositories;


public interface IActorsRepository
{
    Task<Actor> CreateActorAsync(string name, int age);
    
    Task DeleteActorAsync(int actorId);

    Task<List<Actor>> ListAllActorsAsync();
    Task<List<Actor>> GetActorsWithMoviesAsync();

    Task UpdateActorAsync(
        int actorId,
        string name,
        int age);
}
