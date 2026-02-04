using Movies_EFCore.Domain.Repositories;
using Movies_EFCore.Entities;

namespace Movies_EFCore.Services;

public class DirectorService
{
    private readonly IDirectorRepository _directorRepository;

    public DirectorService(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
    }

    public async Task<Director> CreateDirectorAsync(
        string name,
        int age)
    {
        return await _directorRepository.CreateDirectorAsync(name, age);
    }


    public async Task<List<Director>> ListAllDirectorsAsync()
    {
        var directors = await _directorRepository.ListAllDirectorsAsync();
        
        return directors;

    }


    public async Task UpdateDirectorAsync(int directorId,
        string name,
        int age)
    {
        await _directorRepository.UpdateDirectorAsync(directorId, name, age);
    }

    public async Task<Director> DeleteDirectorAsync(int directorId)
    {
        return await _directorRepository.DeleteDirectorAsync(directorId);
    }

}