using Movies_EFCore.Domain.DTOs;
using Movies_EFCore.Domain.Repositories;
using Movies_EFCore.Entities;

namespace Movies_EFCore.Services;

public class MovieService
{
    private readonly IMoviesRepository _moviesRepository;

    // 1. Service tar emot repository via constructor
    public MovieService(IMoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
    }

    // 2. Use case: skapa film
    public async Task<Movie> CreateMovieAsync(
        string title, 
        int year, 
        List<string> actorNames, 
        string directorNames, 
        List<string> genreNames)
    {
        // 3. Delegera datalagring till repository
        return await _moviesRepository.CreateMovieAsync(title, year, actorNames, directorNames, genreNames);
    }
    

    public async Task<List<Movie>> ListAllMoviesAsync()
    {
        
        var movies = await _moviesRepository.ListAllMoviesAsync();
        
        return movies;
    }

    public async Task<List<Movie>> DeleteMovieAsync(int movieId)
    {
        return await _moviesRepository.DeleteMovieAsync(movieId);
    }

    public async Task<List<Movie>> UpdateMovieAsync(
        int movieId,
        string title,
        int year,
        List<string> actorNames,
        string directorName,
        List<string> genreNames)
    {

        return await _moviesRepository.UpdateMovieAsync(movieId, title, year, actorNames, directorName, genreNames);
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