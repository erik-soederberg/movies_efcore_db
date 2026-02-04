using Movies_EFCore.Services;
using Movies_EFCore.UI;

namespace Movies_EFCore.UI;

public class Menu
{
    private readonly MovieMenu _movieMenu;
    private readonly ActorMenu _actorMenu;
    private readonly DirectorMenu _directorMenu;
    private readonly GenreMenu _genreMenu;

    public Menu(MovieMenu movieMenu, ActorMenu actorMenu, DirectorMenu directorMenu, GenreMenu genreMenu)
    {
        _movieMenu = movieMenu;
        _actorMenu = actorMenu;
        _directorMenu = directorMenu;
        _genreMenu = genreMenu;
    }

    public async Task StartAsync()
    {
        
        Console.Clear();
        var running = true;

        while (running)
        {
            Console.WriteLine("--- Movies EF Core ---");
            Console.WriteLine("1. Manage movies");
            Console.WriteLine("2. Manage actors");
            Console.WriteLine("3. Manage directors ");
            Console.WriteLine("4. Manage genres");
            Console.WriteLine("0. Exit");

            var input = Console.ReadLine();

            if (!int.TryParse(input, out var choice))
            {
                Console.WriteLine("Invalid choice");
                continue;
            }

            switch (choice)
            {
                case 1:
                    await _movieMenu.StartAsync();
                    break;
                
                case 2:
                    await _actorMenu.StartAsync();
                    break;
                
                case 3:
                    await _directorMenu.StartAsync();
                    break;
                
                case 4: 
                    await _genreMenu.StartAsync();
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
}
    