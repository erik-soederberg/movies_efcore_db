namespace Movies_EFCore.UI;
using Movies_EFCore.Services;

public class DirectorMenu
{
    private readonly DirectorService _directorService;

    public DirectorMenu(DirectorService directorService)
    {
        _directorService = directorService;
    }

    public async Task StartAsync()
    {
        var running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("--- Directors EF Core ---");
            Console.WriteLine("1. Create director");
            Console.WriteLine("2. List all directors");
            Console.WriteLine("3. Update director");
            Console.WriteLine("4. Delete director");
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
                    await CreateDirectorAsync();
                    break;

                case 2:
                    await ListAllDirectorsAsync();
                    break;
                
                case 3: 
                    await UpdateDirectorAsync();
                    break;
                
                case 4: 
                    await DeleteDirectorAsync();
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

    public async Task CreateDirectorAsync()
    {
        Console.Clear();

        Console.WriteLine("Enter director name: ");
        var directorName = Console.ReadLine();

        Console.WriteLine("Enter director age: ");
        if (!int.TryParse(Console.ReadLine(), out var directorAge))
        {
            Console.WriteLine("Invalid input!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        try
        {
            if (!string.IsNullOrWhiteSpace(directorName))
            {
                var director = await _directorService.CreateDirectorAsync(directorName, directorAge);
                Console.WriteLine($"Director {director.Name} created successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public async Task ListAllDirectorsAsync()
    {
        Console.Clear();

        var directors = await _directorService.ListAllDirectorsAsync();

        foreach (var director in directors)
        {
            Console.WriteLine($"Director ID: {director.DirectorId}");
            Console.WriteLine($"Name: {director.Name}");
            Console.WriteLine($"Age: {director.Age}");
            Console.WriteLine("---------------------------");
        }

        if (directors.Count == 0)
        {
            Console.WriteLine("No directors found");
        }
        
        Console.ReadKey();
    }

    public async Task UpdateDirectorAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Update director ---");

        Console.WriteLine("Enter director ID to update: ");
        var input = Console.ReadLine();

        if (!int.TryParse(input, out var directorId))
        {
            Console.WriteLine("Invalid ID input!");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Enter new director name: ");
        var newName = Console.ReadLine();

        Console.WriteLine("Enter new director age: ");
        if (!int.TryParse(Console.ReadLine(), out var newAge))
        {
            Console.WriteLine("Invalid age input!");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\nAre you sure you want to update this director? (y/n): ");
        var confirm = Console.ReadLine()?.ToLower();

        if (confirm != "y")
        {
            Console.WriteLine("Update cancelled.");
            Console.ReadKey();
            return;
        }

        try
        {
            if (!string.IsNullOrWhiteSpace(newName))
                await _directorService.UpdateDirectorAsync(directorId, newName, newAge);

            Console.WriteLine("Director updated successfully.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message); // t.ex. "Director not found"
        }

        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }

    public async Task DeleteDirectorAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Delete director ---");
        Console.Write("Enter director ID: ");

        if (!int.TryParse(Console.ReadLine(), out var directorId))
        {
            Console.WriteLine("Invalid ID.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Are you sure you want to delete this director? (y/n)");
        var confirm = Console.ReadLine()?.ToLower();

        if (confirm != "y")
        {
            Console.WriteLine("Delete cancelled.");
            Console.ReadKey();
            return;
        }

        try
        {
            await _directorService.DeleteDirectorAsync(directorId);
            Console.WriteLine("Director deleted successfully.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message); // t.ex. "Director not found"
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}





