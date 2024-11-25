using Microsoft.AspNetCore.Mvc;
using SOAP_LibrosApp.Models;
using SOAP_LibrosApp.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SOAP_LibrosApp.Controllers
{
    public class LibroController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public LibroController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // LISTAR TODOS LOS LIBROS (ya configurado)
        public async Task<IActionResult> Index()
        {
            try
            {
                var librosSql = await _dbContext.Libros.ToListAsync();

                if (!librosSql.Any())
                {
                    ViewBag.Message = "No se encontraron libros en la base de datos.";
                }

                return View(librosSql);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al cargar los libros: {ex.Message}";
                return View(new List<Libro>());
            }
        }

        // FORMULARIO PARA CREAR UN NUEVO LIBRO
        public IActionResult Crear()
        {
            return View();
        }

        // CREAR NUEVO LIBRO (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Libro libro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Validar si el ID ya existe en la base de datos
                    var existeLibro = await _dbContext.Libros.AnyAsync(l => l.Id == libro.Id);
                    if (existeLibro)
                    {
                        ModelState.AddModelError("Id", "Ya existe un libro con este ID. Por favor, elige otro.");
                        return View(libro); // Devolver la vista con el mensaje de error
                    }

                    // Guardar en la base de datos
                    _dbContext.Libros.Add(libro);
                    await _dbContext.SaveChangesAsync();

                    // Redirigir al índice después de crear
                    return RedirectToAction("Index");
                }

                // Si el modelo no es válido, devolver la vista con los errores
                return View(libro);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al crear el libro: {ex.Message}";
                return View(libro);
            }
        }


        // FORMULARIO PARA EDITAR UN LIBRO
        public async Task<IActionResult> Editar(int id)
        {
            try
            {
                var libro = await _dbContext.Libros.FindAsync(id);

                if (libro == null)
                {
                    return NotFound();
                }

                return View(libro);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al cargar el libro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        // ACTUALIZAR LIBRO (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Libro libro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Actualizar el libro en la base de datos
                    _dbContext.Libros.Update(libro);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(libro);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al actualizar el libro: {ex.Message}";
                return View(libro);
            }
        }

        // FORMULARIO PARA ELIMINAR UN LIBRO
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var libro = await _dbContext.Libros.FindAsync(id);

                if (libro == null)
                {
                    return NotFound();
                }

                return View(libro);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al cargar el libro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        // CONFIRMAR ELIMINACIÓN (POST)
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminacion(int id)
        {
            try
            {
                var libro = await _dbContext.Libros.FindAsync(id);

                if (libro != null)
                {
                    _dbContext.Libros.Remove(libro);
                    await _dbContext.SaveChangesAsync();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al eliminar el libro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
