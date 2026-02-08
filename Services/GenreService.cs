using Movies_EFCore.Domain.Repositories;
using Movies_EFCore.Entities;

namespace Movies_EFCore.Services;

public class GenreService
{
    
    private readonly IGenresRepository _genresRepository;
    
    public GenreService(IGenresRepository genresRepository)
    {
        _genresRepository = genresRepository;
    }
    
    public async Task <Genre> CreateGenreAsync(string name)
    {
        return await _genresRepository.CreateGenreAsync(name);
    }


    public async Task<List<Genre>> ListAllGenresAsync()
    {
        var genres = await _genresRepository.ListAllGenresAsync();
        
        return genres;
    }

    public async Task UpdateGenreAsync(int genreId, string newName)
    {
         await _genresRepository.UpdateGenreAsync(genreId, newName);
    }
    
    public async Task DeleteGenreAsync(int genreId)
    {
        await _genresRepository.DeleteGenreAsync(genreId);
    }


}