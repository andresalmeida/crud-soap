using System.ComponentModel.DataAnnotations;

namespace SOAP_LibrosApp.Models
{
    public class Libro
    {
        [Key]
        [Required(ErrorMessage = "El ID es obligatorio.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, ErrorMessage = "El título no puede tener más de 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El autor es obligatorio.")]
        [StringLength(100, ErrorMessage = "El autor no puede tener más de 100 caracteres.")]
        public string Autor { get; set; } = string.Empty;

        [Required(ErrorMessage = "El año de publicación es obligatorio.")]
        [Range(1500, 2100, ErrorMessage = "El año debe estar entre 1500 y 2100.")]
        public int AñoPublicacion { get; set; }
    }
}
