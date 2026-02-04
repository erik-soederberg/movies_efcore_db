using Movies_EFCore.Entities;
namespace Movies_EFCore.Domain.Repositories;

public interface IGenresRepository
{
    
    Task<Genre> CreateGenreAsync(string name);
    
    Task<List<Genre>> ListAllGenresAsync();
    
    Task<List<Genre>> UpdateGenreAsync(int genreId, string name);
    
    Task<Genre> DeleteGenreAsync(int genreId);
    
}