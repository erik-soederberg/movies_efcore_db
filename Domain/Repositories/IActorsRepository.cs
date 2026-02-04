using Movies_EFCore.Entities;

namespace Movies_EFCore.Domain.Repositories;


public interface IActorsRepository
{
    Task<Actor> CreateActorAsync(string name, int age);
    

    Task<Actor> DeleteActorAsync(int actorId);

    Task<List<Actor>> ListAllActorsAsync();

    Task<List<Actor>> UpdateActorAsync(
        int actorId,
        string name,
        int age);
    
    Task<List<Actor>> GetActorsWithMoviesAsync();


}
