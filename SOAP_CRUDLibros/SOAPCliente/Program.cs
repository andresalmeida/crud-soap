using System;
using SOAPCliente.BookServiceReference; // Espacio de nombres para el cliente generado por la referencia del servicio

class Program
{
    static void Main(string[] args)
    {
        var client = new BookServiceClient();
        bool continuar = true;

        while (continuar)
        {
            // Limpia la consola antes de mostrar el menú
            Console.Clear();
            Console.WriteLine("--- Menú CRUD de Libros ---");
            Console.WriteLine("1. Crear un libro");
            Console.WriteLine("2. Obtener un libro por ID");
            Console.WriteLine("3. Obtener todos los libros");
            Console.WriteLine("4. Actualizar un libro");
            Console.WriteLine("5. Eliminar un libro");
            Console.WriteLine("6. Salir");
            Console.Write("Selecciona una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CrearLibro(client);
                    break;

                case "2":
                    ObtenerLibroPorId(client);
                    break;

                case "3":
                    ObtenerTodosLosLibros(client);
                    break;

                case "4":
                    ActualizarLibro(client);
                    break;

                case "5":
                    EliminarLibro(client);
                    break;

                case "6":
                    continuar = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida. Presiona Enter para intentar de nuevo.");
                    Console.ReadLine(); // Pausa para que el usuario vea el mensaje
                    break;
            }
        }

        client.Close();
    }

    static void CrearLibro(BookServiceClient client)
    {
        Console.Clear();
        Console.WriteLine("--- Crear un nuevo libro ---");
        Console.Write("ID del libro: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Título del libro: ");
        string titulo = Console.ReadLine();

        Console.Write("Autor del libro: ");
        string autor = Console.ReadLine();

        Console.Write("Año de publicación: ");
        int anio = int.Parse(Console.ReadLine());

        var nuevoLibro = new Libro
        {
            Id = id,
            Titulo = titulo,
            Autor = autor,
            AñoPublicacion = anio
        };

        var resultado = client.CrearLibro(nuevoLibro);
        Console.WriteLine($"Libro creado: {resultado.Titulo}, Autor: {resultado.Autor}");
        Pausar();
    }

    static void ObtenerLibroPorId(BookServiceClient client)
    {
        Console.Clear();
        Console.WriteLine("--- Obtener un libro por ID ---");
        Console.Write("Ingresa el ID del libro: ");
        int id = int.Parse(Console.ReadLine());

        var libro = client.ObtenerLibro(id);
        if (libro != null)
        {
            Console.WriteLine($"Libro encontrado: ID={libro.Id}, Título={libro.Titulo}, Autor={libro.Autor}, Año={libro.AñoPublicacion}");
        }
        else
        {
            Console.WriteLine("No se encontró un libro con ese ID.");
        }
        Pausar();
    }

    static void ObtenerTodosLosLibros(BookServiceClient client)
    {
        Console.Clear();
        Console.WriteLine("--- Obtener todos los libros ---");
        var libros = client.ObtenerTodosLosLibros();

        if (libros != null && libros.Length > 0)
        {
            Console.WriteLine("Lista de libros:");
            foreach (var libro in libros)
            {
                Console.WriteLine($"ID={libro.Id}, Título={libro.Titulo}, Autor={libro.Autor}, Año={libro.AñoPublicacion}");
            }
        }
        else
        {
            Console.WriteLine("No hay libros registrados.");
        }
        Pausar();
    }

    static void ActualizarLibro(BookServiceClient client)
    {
        Console.Clear();
        Console.WriteLine("--- Actualizar un libro ---");
        Console.Write("ID del libro a actualizar: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Nuevo título: ");
        string titulo = Console.ReadLine();

        Console.Write("Nuevo autor: ");
        string autor = Console.ReadLine();

        Console.Write("Nuevo año de publicación: ");
        int anio = int.Parse(Console.ReadLine());

        var libroActualizado = new Libro
        {
            Id = id,
            Titulo = titulo,
            Autor = autor,
            AñoPublicacion = anio
        };

        var resultado = client.ActualizarLibro(libroActualizado);

        if (resultado != null)
        {
            Console.WriteLine($"Libro actualizado: ID={resultado.Id}, Título={resultado.Titulo}, Autor={resultado.Autor}, Año={resultado.AñoPublicacion}");
        }
        else
        {
            Console.WriteLine("No se encontró un libro con ese ID para actualizar.");
        }
        Pausar();
    }

    static void EliminarLibro(BookServiceClient client)
    {
        Console.Clear();
        Console.WriteLine("--- Eliminar un libro ---");
        Console.Write("Ingresa el ID del libro a eliminar: ");
        int id = int.Parse(Console.ReadLine());

        var eliminado = client.EliminarLibro(id);

        if (eliminado)
        {
            Console.WriteLine($"Libro con ID={id} eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontró un libro con ese ID para eliminar.");
        }
        Pausar();
    }

    static void Pausar()
    {
        Console.WriteLine("\nPresiona Enter para regresar al menú principal...");
        Console.ReadLine();
    }
}

