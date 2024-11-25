# Sistema CRUD SOAP de Libros

Sistema completo de gestión de libros construido con .NET que implementa servicios web SOAP para operaciones CRUD. El sistema incluye tanto un cliente de consola como una interfaz web con integración a SQL Server.

## Características

- Implementación de Servicio Web SOAP para gestión de libros
- Operaciones CRUD completas (Crear, Leer, Actualizar, Eliminar)
- Dos implementaciones de cliente:
  - Interfaz basada en consola
  - Interfaz web con estilo Bootstrap
- Integración con base de datos SQL Server
- Arquitectura MVC
- Diseño responsivo

## Tecnologías Utilizadas

- ASP.NET Core
- Entity Framework Core
- SQL Server
- WCF (Windows Communication Foundation)
- Bootstrap
- Servicios Web SOAP

## Arquitectura del Sistema

El sistema está dividido en tres componentes principales:

1. **Servidor SOAP**
   - Maneja la implementación del servicio SOAP
   - Gestiona operaciones de base de datos
   - Implementa la lógica de negocio

2. **Cliente de Consola**
   - Interfaz de línea de comandos
   - Consumo directo del servicio SOAP
   - Menú interactivo para operaciones CRUD

3. **Interfaz Web**
   - Aplicación web basada en MVC
   - Diseño responsivo usando Bootstrap
   - Interfaz amigable para gestión de libros

## Instrucciones de Configuración

### Prerrequisitos

- Visual Studio 2022
- SQL Server
- .NET Framework/Core

### Configuración de Base de Datos

1. Crear una base de datos llamada `LibrosDB`
2. Ejecutar el siguiente script SQL:

```sql
CREATE TABLE Libros (
    Id INT PRIMARY KEY,
    Titulo NVARCHAR(255) NOT NULL,
    Autor NVARCHAR(255) NOT NULL,
    AñoPublicacion INT NOT NULL
);
```

### Configuración

1. Actualizar la cadena de conexión en `web.config`:

```xml
<connectionStrings>
    <add name="LibrosDB"
         connectionString="Server=TU_SERVIDOR;Database=LibrosDB;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;"
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

2. Actualizar el endpoint del servicio SOAP en la configuración del cliente:

```xml
<endpoint address="http://localhost:64441/BookService.svc"
          binding="wsHttpBinding"
          contract="BookServiceReference.IBookService"
          name="WSHttpBinding_IBookService" />
```

## Estructura del Proyecto

- `SOAPServer/`: Contiene la implementación del servicio SOAP
  - `IBookService.cs`: Interfaz del servicio
  - `BookService.svc`: Implementación del servicio
  - `Libro.cs`: Modelo de entidad libro

- `SOAPCliente/`: Implementación del cliente de consola
  - `Program.cs`: Aplicación principal de consola
  - Configuración de servicios conectados

- `SOAP_LibrosApp/`: Interfaz web
  - `Controllers/`: Controladores MVC
  - `Models/`: Modelos de datos
  - `Views/`: Plantillas de interfaz de usuario
  - `wwwroot/`: Archivos estáticos (CSS, JS)

## Ejecución de la Aplicación

1. Iniciar el proyecto del Servidor SOAP
2. Ejecutar el Cliente de Consola o la Interfaz Web
3. Para el cliente de consola, seguir las opciones del menú en pantalla
4. Para la interfaz web, navegar a la URL local proporcionada

## Características en Detalle

### Cliente de Consola
- Sistema de menú interactivo
- Visualización clara de resultados de operaciones
- Manejo de errores y retroalimentación al usuario

### Interfaz Web
- Diseño responsivo
- Operaciones CRUD intuitivas
- Retroalimentación visual para acciones del usuario
- UI limpia y moderna

## Consideraciones de Seguridad

- Validación de entradas implementada
- Protección contra inyección SQL mediante consultas parametrizadas
- Manejo de errores y registro

## Recomendaciones Futuras

- Implementar autenticación y autorización
- Agregar registro de errores más completo
- Optimizar consultas de base de datos para conjuntos de datos más grandes
- Considerar implementar alternativas REST o GraphQL
- Agregar pruebas de usuario y mecanismos de retroalimentación
- Mejorar la documentación con especificaciones de API

## Contribuir

1. Hacer fork del repositorio
2. Crear tu rama de características (`git checkout -b feature/TuCaracteristica`)
3. Hacer commit de tus cambios (`git commit -m 'Agregar alguna característica'`)
4. Hacer push a la rama (`git push origin feature/TuCaracteristica`)
5. Abrir un Pull Request

## Autores

- Almeida Andrés
- Moncayo Paola
- Valdiviezo Darwin

## Licencia

Este proyecto está licenciado bajo la Licencia MIT - ver el archivo LICENSE para más detalles
