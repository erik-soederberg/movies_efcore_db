using Movies_EFCore.Repositories;
using Movies_EFCore.Services;
using Movies_EFCore.UI;

// --------------------
// Repositories
// --------------------

var movieRepository = new MoviesRepository();
var actorRepository = new ActorsRepository();
var directorRepository = new DirectorsRepository();
var genreRepository = new GenresRepository();

// --------------------
// Services
// --------------------

var movieService = new MovieService(movieRepository);
var actorService = new ActorService(actorRepository);
var directorService = new DirectorService(directorRepository);
var genreService = new GenreService(genreRepository);

// --------------------
// Menus
// --------------------

var movieMenu = new MovieMenu(movieService);
var actorMenu = new ActorMenu(actorService);
var directorMenu = new DirectorMenu(directorService);
var genreMenu = new GenreMenu(genreService);

// --------------------
// Main Menu
// --------------------

var menu = new Menu(movieMenu, actorMenu, directorMenu, genreMenu);

// --------------------
// Start app
// --------------------

await menu.StartAsync();
