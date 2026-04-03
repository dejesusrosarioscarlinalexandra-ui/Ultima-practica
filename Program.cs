using Bookcase.Database;
using Bookcase.Repository;
using Bookcase.Services;
using Bookcase.Screens;

using var context = new AppDbContext();

// Crear base de datos automáticamente
context.Database.EnsureCreated();

var repo = new MiembroRepository(context);
var service = new MiembroService(repo);
var screen = new MainScreen(service);

screen.Show();