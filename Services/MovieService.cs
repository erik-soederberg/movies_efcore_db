using Movies_EFCore.Domain.DTOs;
using Movies_EFCore.Domain.Repositories;
using Movies_EFCore.Entities;

namespace Movies_EFCore.Services;

public class MovieService
{
    private readonly IMoviesRepository _moviesRepository;
    
    public MovieService(IMoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
    }
    
    public async Task<Movie> CreateMovieAsync(
        string title, 
        int year, 
        List<string> actorNames, 
        string directorNames, 
        List<string> genreNames)
    {
        return await _moviesRepository.CreateMovieWithTransactionAsync(title, year, actorNames, directorNames, genreNames);
    }
    

    public async Task<List<Movie>> ListAllMoviesAsync()
    {
        var movies = await _moviesRepository.ListAllMoviesAsync();
        
        return movies;
    }

    public async Task DeleteMovieAsync(int movieId)
    { 
        await _moviesRepository.DeleteMovieAsync(movieId);
    }

    public async Task UpdateMovieAsync(
        int movieId,
        string title,
        int year,
        List<string> actorNames,
        string directorName,
        List<string> genreNames)
    {
        await _moviesRepository.UpdateMovieAsync(movieId, title, year, actorNames, directorName, genreNames);
    }
    
    public async Task AddActorToMovieAsync(int movieId, int actorId)
    {
        await _moviesRepository.AddActorToMovieAsync(movieId, actorId);
    }
    
    public async Task RemoveActorFromMovieAsync(int movieId, int actorId)
    {
        await _moviesRepository.RemoveActorFromMovieAsync(movieId, actorId);
    }

    public async Task<List<MovieReleaseSummary>> FetchReleaseSummariesAsync()
    {
        return await _moviesRepository.FetchReleaseSummariesAsync();
    }
    
    public async Task<Dictionary<string, int>> FetchDirectorsMoviesCountAsync()
    {
        return await _moviesRepository.FetchDirectorsMoviesCountAsync();
    }

}