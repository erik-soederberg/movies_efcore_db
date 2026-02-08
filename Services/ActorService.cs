using Movies_EFCore.Entities;
using Movies_EFCore.Domain.Repositories;

namespace Movies_EFCore.Services;

public class ActorService
{
    private readonly IActorsRepository _actorsRepository;

    public ActorService(IActorsRepository actorsRepository)
    {
        _actorsRepository = actorsRepository;
    }

    public async Task<Actor> CreateActorAsync(
        string name,
        int age)
    {
        return await _actorsRepository.CreateActorAsync(name, age);
    }

    public async Task DeleteActorAsync(int actorId)
    { 
        await _actorsRepository.DeleteActorAsync(actorId);
    }
    
    public async Task<List<Actor>> ListAllActorsAsync()
    {
        var actors = await _actorsRepository.ListAllActorsAsync();

        return actors; 
    }


    public async Task UpdateActorAsync(
        int actorId,
        string newName,
        int newAge)
    {
         await _actorsRepository.UpdateActorAsync(actorId, newName, newAge);
    }
    
    public async Task<List<Actor>> GetActorsWithMoviesAsync()
    {
        return await _actorsRepository.GetActorsWithMoviesAsync();
    }


}


    




















