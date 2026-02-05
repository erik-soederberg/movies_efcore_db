namespace Movies_EFCore.UI;
using Movies_EFCore.Services;


public class MovieMenu
{
    private readonly MovieService _movieService;

    public MovieMenu(MovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task StartAsync()
    {
        var running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Movie Menu ===");
            Console.WriteLine("1. Create movie");
            Console.WriteLine("2. List all movies");
            Console.WriteLine("3. Update Movie");
            Console.WriteLine("4. Delete movie");
            Console.WriteLine("5. Add actor to movie");
            Console.WriteLine("6. Remove actor from movie");
            Console.WriteLine("7. Show movies sorted by release year");
            Console.WriteLine("0. Back");

            Console.Write("Choice: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out var choice))
            {
                Console.WriteLine("Invalid choice");
                Console.ReadKey();
                continue;
            }

            switch (choice)
            {
                case 1:
                    await CreateMovieAsync();
                    break;

                case 2:
                    await ListAllMoviesAsync();
                    break;

                case 3:
                    await UpdateMovieAsync();
                    break;

                case 4:
                    await DeleteMovieAsync();
                    break;
                
                case 5:
                    await AddActorToMovieAsync();
                    break;
                
                case 6:
                    await RemoveActorFromMovieAsync();
                    break;
                
                case 7:
                    await FetchReleaseSummariesAsync();
                    break;
                

                case 0:
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    break;
            }
        }
    }
    
    

    public async Task CreateMovieAsync()
    {
        Console.Clear();

        Console.WriteLine("Title: ");
        var title = Console.ReadLine();

        Console.WriteLine("Year: ");
        if (!int.TryParse(Console.ReadLine(), out var year))
        {
            Console.WriteLine("Invalid year");
            return;
        }

        Console.WriteLine("Actors (comma separated): ");
        var actorInput = Console.ReadLine() ?? "";
        var actorNames = actorInput
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(a => a.Trim())
            .ToList();

        Console.WriteLine("Director: ");
        var directorInput = Console.ReadLine() ?? "";
        var directorNames = directorInput;

        Console.WriteLine("Genre: ");
        var genreInput = Console.ReadLine() ?? "";
        var genreNames = genreInput
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(a => a.Trim())
            .ToList();

        try
        {
            var movie = await _movieService.CreateMovieAsync(title!, year, actorNames, directorNames, genreNames);
            Console.WriteLine($"Movie created with ID {movie.MovieId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }
    
    public async Task ListAllMoviesAsync()
    {
        Console.Clear();

        var movies = await _movieService.ListAllMoviesAsync();

        foreach (var movie in movies)
        {
            // Skriv ut filmens ID, titel och år
            Console.WriteLine($"{movie.MovieId} - {movie.MovieTitle} ({movie.ReleaseYear})");

            // Skriv ut aktörer om det finns några
            if (movie.Actors.Count != 0)
            {
                Console.WriteLine("Actors: " + string.Join(", ", movie.Actors.Select(a => a.Name)));

            }
        }

        Console.ReadKey();
    }

    public async Task DeleteMovieAsync()
    {
        Console.Clear();

        Console.WriteLine($"Enter movie ID to delete from database: ");
        var input = Console.ReadLine();
            
        Console.WriteLine($"Are you sure you want to delete this movie? (y/n)");
        var confirm = Console.ReadLine()?.ToLower();    
            
        if (confirm != "y") {
            Console.WriteLine("Delete cancelled.");
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        if (int.TryParse(input, out var movieId))
        {
            await _movieService.DeleteMovieAsync(movieId);
            Console.WriteLine("Movie deleted.");
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }

        Console.ReadKey();
    }

    public async Task UpdateMovieAsync()
    {
        Console.Clear();

        Console.Write("Movie ID: ");
        if (!int.TryParse(Console.ReadLine(), out var movieId))
        {
            Console.WriteLine("Invalid ID.");
            Console.ReadKey();
            return;
        }

        Console.Write("New title: ");
        var title = Console.ReadLine() ?? "";

        Console.Write("New year: ");
        int.TryParse(Console.ReadLine(), out var year);

        Console.Write("New actors (comma separated): ");
        var actorInput = Console.ReadLine() ?? "";

        var actorNames = actorInput
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(a => a.Trim())
            .ToList();

        Console.Write("New director: ");
        var directorName = Console.ReadLine() ?? "";

        Console.Write("New genres (comma separated): ");
        var genreInput = Console.ReadLine() ?? "";

        var genreNames = genreInput
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(g => g.Trim())
            .ToList();

        try
        {
            await _movieService.UpdateMovieAsync(
                movieId,
                title,
                year,
                actorNames,
                directorName,
                genreNames);

            Console.WriteLine("Movie updated.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }

    
    private async Task AddActorToMovieAsync()
    {
        Console.Clear();

        Console.Write("Movie ID: ");
        var movieId = int.Parse(Console.ReadLine()!);

        Console.Write("Actor ID: ");
        var actorId = int.Parse(Console.ReadLine()!);

        await _movieService.AddActorToMovieAsync(movieId, actorId);

        Console.WriteLine("Actor added to movie.");
        Console.ReadKey();
    }

    private async Task RemoveActorFromMovieAsync()
    {
        Console.Clear();
        
        Console.Write("Movie ID: ");
        var movieId = int.Parse(Console.ReadLine()!);

        Console.Write("Actor ID: ");
        var actorId = int.Parse(Console.ReadLine()!);
        
        Console.WriteLine("\nAre you sure you want to delete this actor from the movie? (y/n): ");
        var confirm = Console.ReadLine()?.ToLower();

        if (confirm != "y")
        {
            Console.WriteLine("Update cancelled.");
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
            return;
        }
        
        await _movieService.RemoveActorFromMovieAsync(movieId, actorId);
        
        Console.WriteLine("Actor removed from movie.");
        
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
        
    }

    public async Task FetchReleaseSummariesAsync()
    {
        Console.Clear();
        
        var movies = await _movieService.FetchReleaseSummariesAsync();

        foreach (var m in movies)
        {
            Console.WriteLine($"{m.Year} - {m.Title} - {m.Director}");
        }
    }

}