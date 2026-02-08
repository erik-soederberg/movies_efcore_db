using Movies_EFCore.Entities;
namespace Movies_EFCore.Domain.Repositories;

public interface IGenresRepository
{
    Task<Genre> CreateGenreAsync(string name);          

    Task<List<Genre>> ListAllGenresAsync();             

    Task UpdateGenreAsync(int genreId, string name);    

    Task DeleteGenreAsync(int genreId);                 
}