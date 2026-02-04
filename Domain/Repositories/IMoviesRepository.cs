using Movies_EFCore.Entities;

namespace Movies_EFCore.Domain.Repositories;
/*
 *
 * Ett interface definierar VAD som skall göras, inte HUR.
 * Vi kan använda ett interface för att göra som "regler" på vad som skall göras,
 * sedan testar implementationer mot interface för att undvika att testa direkt mot databasen.
 *
 */

public interface IMoviesRepository
{
    /* "Vi säger till programmet att det förväntas en metod "CreateMovieAsync" med parametrarna string title och int year, och en 
     *  metod GetMovieAsync" med parametern int id. 
     *  "De här metoderna ska finnas" - men inte hur de fungerar. 
    */
    Task<Movie> CreateMovieAsync(
        string title, 
        int year, 
        List<string> actorNames, 
        string directorNames, 
        List<string> genreNames);
    // Task<Movie> GetMovieAsync(int movieId);
    
    // 2. Kontrakt för att hämta alla filmer
    //    Ingen EF Core-logik här – bara signaturen
    // (Senare kan du lägga till GetMovieByIdAsync, etc.)

    Task<List<Movie>> ListAllMoviesAsync(); 
    
    Task<List<Movie>> DeleteMovieAsync(int movieId);
    
    Task<List<Movie>> UpdateMovieAsync(
        int movieId, 
        string title, 
        int year, 
        List<string> actorNames, 
        string directorNames, 
        List<string> genreNames);
    
    Task AddActorToMovieAsync(int movieId, int actorId);
    
    Task RemoveActorFromMovieAsync(int movieId, int actorId);

}