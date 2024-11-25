using Microsoft.EntityFrameworkCore;
using SOAP_LibrosApp.Models;

namespace SOAP_LibrosApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; } = null!;
    }
}
