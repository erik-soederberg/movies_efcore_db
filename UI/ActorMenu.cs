namespace Movies_EFCore.UI;
using Movies_EFCore.Services;

public class ActorMenu
{
    private readonly ActorService _actorService;

    public ActorMenu(ActorService actorService)
    {
        _actorService = actorService;
    }
    
    public async Task StartAsync()
    {
        var running = true;

        while (running) 
        {
            Console.Clear();
            Console.WriteLine("--- Actors EF Core ---");
            Console.WriteLine("1. Create actor");
            Console.WriteLine("2. List all actors");
            Console.WriteLine("3. Update actor");
            Console.WriteLine("4. Delete actor");
            Console.WriteLine("5. List actors with movies");
            Console.WriteLine("0. Exit");
            
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
                    await CreateActorAsync();
                    break;
                
                case 2: 
                    await ListAllActorsAsync();
                    break;
                
                case 3:
                    await UpdateActorAsync();
                    break;
                
                case 4:
                    await DeleteActorAsync();
                    break;
                
                case 5:
                    await ListActorsWithMoviesAsync();
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
    
    public async Task CreateActorAsync()
    {
        Console.Clear();
        
        Console.WriteLine("Enter actor name: ");
        var actorName = Console.ReadLine();

        Console.WriteLine("Enter actor age: ");
        if (!int.TryParse(Console.ReadLine(), out var actorAge))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        try
        {
            var actor = await _actorService.CreateActorAsync(actorName, actorAge);
            Console.WriteLine($"Actor {actor.Name} created successfully.");

        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadKey();
    }
    
    public async Task DeleteActorAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Delete actor ---");
        Console.WriteLine("Enter actor ID to delete: ");
        var input = Console.ReadLine();

        if (int.TryParse(input, out var actorId))
        {
            await _actorService.DeleteActorAsync(actorId);
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
        
        Console.ReadKey();
        
    }

    public async Task ListAllActorsAsync()
    {
        Console.Clear();

        var actors = await _actorService.ListAllActorsAsync();

        foreach (var actor in actors)
        {
            Console.WriteLine($"Name: {actor.Name}"); 
            Console.WriteLine($"Age: {actor.Age}");
            Console.WriteLine($"Actor ID: {actor.ActorId}");
            Console.WriteLine("---------------------------");
        }
        
        if (actors.Count == 0)
        {
            Console.WriteLine("No actors found");
        }
        
        Console.ReadKey();

    }
    
    public async Task UpdateActorAsync()
    {
        Console.Clear();
        
        Console.WriteLine("--- Update actor ---");
        
        Console.WriteLine("Enter actor ID to update: ");
        var input = Console.ReadLine();
        
        if (int.TryParse(input, out var actorId))
        {
            Console.WriteLine("Enter new actor name: ");
            var newName = Console.ReadLine() ?? "";
            
            Console.WriteLine("Enter new actor age: ");
            if (int.TryParse(Console.ReadLine(), out var newAge))
            {
                Console.WriteLine("\nAre you sure you want to update this actor? (y/n): ");
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
                    await _actorService.UpdateActorAsync(actorId, newName, newAge);
                    Console.WriteLine("Actor updated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid age input!");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID input!");
        }

        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }
    
    public async Task ListActorsWithMoviesAsync()
    {
        Console.Clear();

        var actors = await _actorService.GetActorsWithMoviesAsync();

        if (!actors.Any())
        {
            Console.WriteLine("No actors found.");
            Console.ReadKey();
            return;
        }

        foreach (var actor in actors)
        {
            Console.WriteLine($"Actor: {actor.Name}");

            if (actor.Movies.Any())
            {
                foreach (var movie in actor.Movies)
                {
                    Console.WriteLine($"  - {movie.MovieTitle} ({movie.ReleaseYear})");
                }
            }
            else
            {
                Console.WriteLine("  No movies yet.");
            }

            Console.WriteLine();
        }

        Console.ReadKey();
    }

}













