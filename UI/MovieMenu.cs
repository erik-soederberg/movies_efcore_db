namespace Movies_EFCore.UI;
using Services;

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
            Console.WriteLine("8. Show how many movies each director has made");
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
                case 1: await CreateMovieWithTransactionAsync(); break;
                case 2: await ListAllMoviesAsync(); break;
                case 3: await UpdateMovieAsync(); break;
                case 4: await DeleteMovieAsync(); break;
                case 5: await AddActorToMovieAsync(); break;
                case 6: await RemoveActorFromMovieAsync(); break;
                case 7: await FetchReleaseSummariesAsync(); break;
                case 8: await FetchDirectorsMoviesCountAsync(); break;
                case 0: running = false; break;
                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    break;
            }
        }
    }

    public async Task CreateMovieWithTransactionAsync()
    {
        Console.Clear();

        Console.Write("Title: ");
        var title = Console.ReadLine();

        Console.Write("Year: ");
        if (!int.TryParse(Console.ReadLine(), out var year))
        {
            Console.WriteLine("Invalid year");
            Console.ReadKey();
            return;
        }

        Console.Write("Actors (comma separated): ");
        var actorInput = Console.ReadLine() ?? "";
        var actorNames = actorInput.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).ToList();

        Console.Write("Director: ");
        var directorName = Console.ReadLine() ?? "";

        Console.Write("Genres (comma separated): ");
        var genreInput = Console.ReadLine() ?? "";
        var genreNames = genreInput.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(g => g.Trim()).ToList();

        try
        {
            var movie = await _movieService.CreateMovieAsync(title!, year, actorNames, directorName, genreNames);
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
            Console.WriteLine($"{movie.MovieId} - {movie.MovieTitle} ({movie.ReleaseYear})");
            if (movie.Actors.Count > 0)
                Console.WriteLine("Actors: " + string.Join(", ", movie.Actors.Select(a => a.Name)));
        }

        Console.ReadKey();
    }

    public async Task DeleteMovieAsync()
    {
        Console.Clear();
        Console.Write("Enter movie ID to delete: ");
        var input = Console.ReadLine();

        Console.Write("Are you sure you want to delete this movie? (y/n): ");
        var confirm = Console.ReadLine()?.ToLower();

        if (confirm != "y")
        {
            Console.WriteLine("Delete cancelled.");
            Console.ReadKey();
            return; // Viktigt!
        }

        if (int.TryParse(input, out var movieId))
        {
            try
            {
                await _movieService.DeleteMovieAsync(movieId);
                Console.WriteLine("Movie deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
        var actorNames = actorInput.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).ToList();

        Console.Write("New director: ");
        var directorName = Console.ReadLine() ?? "";

        Console.Write("New genres (comma separated): ");
        var genreInput = Console.ReadLine() ?? "";
        var genreNames = genreInput.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(g => g.Trim()).ToList();

        try
        {
            await _movieService.UpdateMovieAsync(movieId, title, year, actorNames, directorName, genreNames);
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
        if (!int.TryParse(Console.ReadLine(), out var movieId)) { Console.WriteLine("Invalid ID"); Console.ReadKey(); return; }

        Console.Write("Actor ID: ");
        if (!int.TryParse(Console.ReadLine(), out var actorId)) { Console.WriteLine("Invalid ID"); Console.ReadKey(); return; }

        try
        {
            await _movieService.AddActorToMovieAsync(movieId, actorId);
            Console.WriteLine("Actor added to movie.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadKey();
    }

    private async Task RemoveActorFromMovieAsync()
    {
        Console.Clear();

        Console.Write("Movie ID: ");
        if (!int.TryParse(Console.ReadLine(), out var movieId)) { Console.WriteLine("Invalid ID"); Console.ReadKey(); return; }

        Console.Write("Actor ID: ");
        if (!int.TryParse(Console.ReadLine(), out var actorId)) { Console.WriteLine("Invalid ID"); Console.ReadKey(); return; }

        Console.Write("Are you sure you want to remove this actor from the movie? (y/n): ");
        var confirm = Console.ReadLine()?.ToLower();

        if (confirm != "y")
        {
            Console.WriteLine("Operation cancelled.");
            Console.ReadKey();
            return;
        }

        try
        {
            await _movieService.RemoveActorFromMovieAsync(movieId, actorId);
            Console.WriteLine("Actor removed from movie.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }

    private async Task FetchReleaseSummariesAsync()
    {
        Console.Clear();

        var movies = await _movieService.FetchReleaseSummariesAsync();
        foreach (var m in movies)
        {
            Console.WriteLine($"{m.Year} - {m.Title} - {m.Director}");
        }

        Console.ReadKey();
    }

    private async Task FetchDirectorsMoviesCountAsync()
    {
        Console.Clear();

        var counts = await _movieService.FetchDirectorsMoviesCountAsync();
        Console.WriteLine("Antal filmer per regissör:\n");

        foreach (var c in counts)
            Console.WriteLine($"{c.Key} has directed {c.Value} movies.");

        Console.ReadKey();
    }
}
