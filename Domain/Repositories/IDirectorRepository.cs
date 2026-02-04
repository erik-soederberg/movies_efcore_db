using Movies_EFCore.Entities;

namespace Movies_EFCore.Domain.Repositories;

public interface IDirectorRepository
{
    Task<Director> CreateDirectorAsync(string name, int age);
    
    Task<List<Director>> ListAllDirectorsAsync();

    Task<List<Director>> UpdateDirectorAsync(
        int directorId,
        string name,
        int age);
    
    Task<Director> DeleteDirectorAsync(int directorId);
}
    
    
