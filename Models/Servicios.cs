using System.ComponentModel.DataAnnotations;

namespace CleanHome.Models
{
    public class Servicios
    {
        [Key]
        public int ServicioId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public double Precio { get; set; }
        
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int Duracion { get; set; }
        public Estados Estado { get; set; } = Estados.Activo;
    }
}