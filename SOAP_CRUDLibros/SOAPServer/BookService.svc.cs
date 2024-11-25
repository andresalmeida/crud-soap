using SOAPServer;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SOAPServer
{

    public class BookService : IBookService
    {
        private readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibrosDB"].ConnectionString;

        public Libro CrearLibro(Libro libro)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Libros (Id, Titulo, Autor, AñoPublicacion) VALUES (@Id, @Titulo, @Autor, @AñoPublicacion)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", libro.Id);
                    command.Parameters.AddWithValue("@Titulo", libro.Titulo);
                    command.Parameters.AddWithValue("@Autor", libro.Autor);
                    command.Parameters.AddWithValue("@AñoPublicacion", libro.AñoPublicacion);

                    command.ExecuteNonQuery();
                }
            }
            return libro;
        }

        public Libro ObtenerLibro(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Libros WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Libro
                            {
                                Id = (int)reader["Id"],
                                Titulo = reader["Titulo"].ToString(),
                                Autor = reader["Autor"].ToString(),
                                AñoPublicacion = (int)reader["AñoPublicacion"]
                            };
                        }
                    }
                }
            }
            return null; // Devuelve null si no encuentra el libro
        }

        public List<Libro> ObtenerTodosLosLibros()
        {
            var libros = new List<Libro>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Libros";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            libros.Add(new Libro
                            {
                                Id = (int)reader["Id"],
                                Titulo = reader["Titulo"].ToString(),
                                Autor = reader["Autor"].ToString(),
                                AñoPublicacion = (int)reader["AñoPublicacion"]
                            });
                        }
                    }
                }
            }
            return libros;
        }

        public Libro ActualizarLibro(Libro libro)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Actualizar el libro en la base de datos
                var query = "UPDATE Libros SET Titulo = @Titulo, Autor = @Autor, AñoPublicacion = @AñoPublicacion WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", libro.Id);
                    command.Parameters.AddWithValue("@Titulo", libro.Titulo);
                    command.Parameters.AddWithValue("@Autor", libro.Autor);
                    command.Parameters.AddWithValue("@AñoPublicacion", libro.AñoPublicacion);

                    var rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Si se actualizó correctamente, devolver el libro actualizado
                        return libro;
                    }
                    else
                    {
                        // Si no se encontró el libro para actualizar, devolver null
                        return null;
                    }
                }
            }
        }

        public bool EliminarLibro(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Libros WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    var rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
