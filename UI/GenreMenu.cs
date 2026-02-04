using Movies_EFCore.Services;

namespace Movies_EFCore.UI;

public class GenreMenu
{
    private readonly GenreService _genreService;

    public GenreMenu(GenreService genreService)
    {
        _genreService = genreService;
    }

    public async Task StartAsync()
    {
        
        var running = true;


        while (running)
        {
            Console.Clear();
            Console.WriteLine("--- Genres EF Core ---");
            Console.WriteLine("1. Create genre");
            Console.WriteLine("2. List all genres");
            Console.WriteLine("3. Update genre");
            Console.WriteLine("4. Delete genre");
            Console.WriteLine("0. Exit");
            
            Console.Write("Choice: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out var choice))
            {
                Console.WriteLine("Invalid Choice");
                Console.ReadKey();
                continue; 
            }

            switch (choice)
            {
                
                case 1:
                await CreateGenreAsync();
                break;
                
                case 2:
                    await ListAllGenresAsync();
                    break;
                
                case 3: 
                    await UpdateGenreAsync();
                    break;
                
                case 4:
                    await DeleteGenreAsync();
                    break;
                case 0: 
                    running = false;
                    break;
                
                default: Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    break;
                
            }
            
        }

    }
    
    public async Task CreateGenreAsync()
    {
        Console.Clear();
        
        Console.WriteLine("Enter genre name: ");
        var genreName = Console.ReadLine();

        try
        {
            var genre = await _genreService.CreateGenreAsync(genreName);
            Console.WriteLine($"Genre {genre.GenreName} created successfully.");
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadKey();
    }

    public async Task ListAllGenresAsync()
    {
        Console.Clear();
        
        var genres = await _genreService.ListAllGenresAsync();
        
        foreach (var genre in genres)
        {
            Console.WriteLine($"Genre ID: {genre.GenreId} - Genrename: {genre.GenreName}");
        }

        if (genres.Count == 0)
        {
            Console.WriteLine("No genres found");
        }
        
        Console.ReadKey();
    }


    public async Task UpdateGenreAsync()
    {
        Console.Clear();
        
        Console.WriteLine("--- Update genre ---");
        
        Console.WriteLine("Enter genre ID to update: ");
        var input = Console.ReadLine();

        if (!int.TryParse(input, out var genreId))
        {
            Console.WriteLine("Invalid ID");
            return;
        }
            
        Console.WriteLine("Enter new genre name: ");
        var genreName = Console.ReadLine();
        
        
        Console.WriteLine("\nAre you sure you want to update this genre? (y/n): ");
        var confirm = Console.ReadLine()?.ToLower();

        if (confirm != "y")
        {
            Console.WriteLine("Update cancelled.");
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
            return;
        }

        try
        {
            await _genreService.UpdateGenreAsync(genreId, genreName);
            Console.WriteLine("Genre updated successfully.");
        }
        
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
        
    }

    public async Task DeleteGenreAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Delete genre ---");
        Console.Write("Enter genre ID: ");
        var input = Console.ReadLine();
        
        
        Console.WriteLine($"Are you sure you want to delete this movie? (y/n)");
        var confirm = Console.ReadLine()?.ToLower();

        if (confirm != "y")
        {
            Console.WriteLine("Delete cancelled."); 
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        if (int.TryParse(input, out var genreId))
        {
            await _genreService.DeleteGenreAsync(genreId);
            Console.WriteLine("Genre deleted.");
        }

        else
        {
            Console.WriteLine("Invalid ID.");
        }
        
        Console.ReadKey();
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}