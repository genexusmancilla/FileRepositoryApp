using FileRepositoryApp;
var builder = WebApplication.CreateBuilder(args);

// Crear una instancia de Startup pasando el builder.Configuration
var startup = new Startup(builder.Configuration);

// Llamar al método Configure usando la instancia de Startup
var app = builder.Build();
startup.Configure(app, builder.Environment);  // Llamada correcta al método de instancia

app.MapGet("/", () => "Hello World!");

app.Run();
