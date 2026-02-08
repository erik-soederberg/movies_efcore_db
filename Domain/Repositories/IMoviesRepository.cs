using Movies_EFCore.Domain.DTOs;
using Movies_EFCore.Entities;
namespace Movies_EFCore.Domain.Repositories;

public interface IMoviesRepository
{
    Task<Movie> CreateMovieWithTransactionAsync(
        string title, 
        int year, 
        List<string> actorNames, 
        string directorNames, 
        List<string> genreNames);

    Task<List<Movie>> ListAllMoviesAsync(); 
    
    Task DeleteMovieAsync(int movieId);
    
    Task UpdateMovieAsync(
        int movieId, 
        string title, 
        int year, 
        List<string> actorNames, 
        string directorNames, 
        List<string> genreNames);
    
    Task AddActorToMovieAsync(int movieId, int actorId);
    
    Task RemoveActorFromMovieAsync(int movieId, int actorId);
    
    
    Task<List<MovieReleaseSummary>> FetchReleaseSummariesAsync();
    
    Task<Dictionary<string,int>> FetchDirectorsMoviesCountAsync();
}