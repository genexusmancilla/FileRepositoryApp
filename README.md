
# FileRepositoryApp

## Descripción

**FileRepositoryApp** es una aplicación diseñada para servir archivos estáticos (como imágenes y PDFs) a través de una API personalizada. Utiliza configuraciones definidas en el archivo `appsettings.json` para controlar las rutas de los archivos servidos.

## Configuración

### appsettings.json

- **ExternalFilePath**: Especifica la ruta física en el servidor donde están almacenados los archivos.
  ```json
  {
    "ExternalFilePath": "C:\Files\ExternalContent"
  }
  ```
  En este ejemplo, los archivos se encuentran en `C:\Files\ExternalContent`.

- **ExternalRequestPath**: Define la ruta virtual (URL) a través de la cual los archivos serán accesibles.
  ```json
  {
    "ExternalRequestPath": "/content"
  }
  ```
  Los archivos estarán disponibles en una URL como `https://misitio.com/content`.

### web.config

El archivo `web.config` es necesario si la aplicación está siendo desplegada en **IIS**. La sección `aspNetCore` se utiliza para configurar cómo el servidor IIS maneja la ejecución de la aplicación ASP.NET Core.

Ejemplo de configuración:

```xml
<configuration>
  <system.webServer>
    <handlers>
      <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
    </handlers>
    <aspNetCore processPath="dotnet" arguments=".\FileRepositoryApp.dll" stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" hostingModel="InProcess" />
  </system.webServer>
</configuration>
```

- **`processPath`**: Especifica el proceso que inicia la aplicación (`dotnet` en este caso).
- **`arguments`**: Indica el archivo de la aplicación que debe ser ejecutado (`FileRepositoryApp.dll`).
- **`stdoutLogFile`**: Define dónde almacenar los logs de salida estándar.

## Uso

1. **Configura las rutas en `appsettings.json`**:
   - **`ExternalFilePath`**: Ruta física donde se almacenan los archivos.
   - **`ExternalRequestPath`**: Ruta virtual a través de la cual se acceden los archivos.

2. **Ejecuta la aplicación**:
   - La aplicación puede ejecutarse localmente utilizando `.NET Core` o desplegarse en un servidor IIS.
   - Si está desplegada en IIS, asegúrate de que la sección `aspNetCore` esté correctamente configurada en el archivo `web.config`.

3. **Acceso a los archivos**:
   - Los archivos almacenados en la carpeta física especificada en `ExternalFilePath` serán accesibles a través de la URL especificada en `ExternalRequestPath`.
   - Por ejemplo, si `ExternalFilePath` está configurado en `C:\Files\ExternalContent` y `ExternalRequestPath` está en `/content`, un archivo `image.png` en esa carpeta será accesible en:
     ```
     https://misitio.com/content/image.png
     ```

## Instalación

1. Clona este repositorio:
   ```bash
   git clone https://github.com/genexusmancilla/FileRepositoryApp.git
   ```

2. Configura las rutas de los archivos en `appsettings.json`.

3. Ejecuta la aplicación localmente o despliega en un servidor IIS.

## Contribuciones

Si deseas contribuir a este proyecto, por favor, envía un pull request con una descripción detallada de los cambios propuestos.

## Licencia

Este proyecto está bajo la licencia MIT.

---

# FileRepositoryApp (English Version)

## Description

**FileRepositoryApp** is an application designed to serve static files (such as images and PDFs) through a custom API. It uses settings defined in the `appsettings.json` file to control the paths of the served files.

## Configuration

### appsettings.json

- **ExternalFilePath**: Specifies the physical path on the server where the files are stored.
  ```json
  {
    "ExternalFilePath": "C:\Files\ExternalContent"
  }
  ```

- **ExternalRequestPath**: Defines the virtual URL path through which the files will be accessible.
  ```json
  {
    "ExternalRequestPath": "/content"
  }
  ```

### web.config

The `web.config` file is necessary if the application is being deployed on **IIS**. The `aspNetCore` section is used to configure how the IIS server handles the execution of the ASP.NET Core application.

Example configuration:

```xml
<configuration>
  <system.webServer>
    <handlers>
      <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
    </handlers>
    <aspNetCore processPath="dotnet" arguments=".\FileRepositoryApp.dll" stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" hostingModel="InProcess" />
  </system.webServer>
</configuration>
```

## Usage

1. **Configure the paths in `appsettings.json`**:
   - **`ExternalFilePath`**: Physical path where the files are stored.
   - **`ExternalRequestPath`**: Virtual URL path through which the files will be accessible.

2. **Run the application**:
   - The application can be run locally using `.NET Core` or deployed to an IIS server.
   - If deployed to IIS, ensure the `aspNetCore` section is correctly configured in the `web.config`.

3. **Accessing the files**:
   - Files stored in the physical path specified in `ExternalFilePath` will be accessible through the URL specified in `ExternalRequestPath`.
   - For example, if `ExternalFilePath` is set to `C:\Files\ExternalContent` and `ExternalRequestPath` is `/content`, a file `image.png` in that folder will be accessible at:
     ```
     https://mysite.com/content/image.png
     ```

## Installation

1. Clone this repository:
   ```bash
   git clone https://github.com/genexusmancilla/FileRepositoryApp.git
   ```

2. Configure the file paths in `appsettings.json`.

3. Run the application locally or deploy it to an IIS server.

## Contributions

If you would like to contribute to this project, please submit a pull request with a detailed description of the proposed changes.

## License

This project is licensed under the MIT License.
