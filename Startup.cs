using Microsoft.Extensions.FileProviders;

namespace FileRepositoryApp
{
    public class Startup(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configuración básica para servir archivos estáticos desde wwwroot
            app.UseStaticFiles();

            // Obtener la ruta externa desde appsettings.json
            string? rutaExterna = _configuration["ExternalFilePath"];
            string? ExternalRequestPath = _configuration["ExternalRequestPath"];

            if (!string.IsNullOrEmpty(rutaExterna) && Directory.Exists(rutaExterna))
            {
                // Configuración para servir archivos desde una carpeta externa
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(rutaExterna),
                    RequestPath = ExternalRequestPath // Ruta virtual para acceder a la carpeta
                });
            }
            else
            {
                // Manejo del caso donde la ruta es nula o no existe
                throw new Exception("La ruta externa para los archivos estáticos no está configurada correctamente o no existe.");
            }
        }
    }
}
