using System.ComponentModel.DataAnnotations;

namespace CleanHome.Models
{
    public class Empleados
    {

        [Key]
        public int EmpleadoId { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression(@"^\d{3}-\d{7}-\d{1}$",
        ErrorMessage = "La cédula debe tener el formato 000-0000000-0")]
        public string Cedula { get; set; } = null;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; } = null;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Correo { get; set; } = null;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$",
        ErrorMessage = "El teléfono debe tener el formato (000) 000-0000")]
        public string Telefono { get; set; } = null;
        
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Cargo { get; set; } = null;
        public Estados Estado { get; set; } = Estados.Activo;

    }
}
