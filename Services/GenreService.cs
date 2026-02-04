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

    public async Task<List<Genre>> UpdateGenreAsync(int genreId, string newName)
    {
        return await _genresRepository.UpdateGenreAsync(genreId, newName);
    }
    
    public async Task<Genre> DeleteGenreAsync(int genreId)
    {
        return await _genresRepository.DeleteGenreAsync(genreId);
    }


}