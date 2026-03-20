using System.ComponentModel.DataAnnotations;

namespace CleanHome.Models
{
    public class Proveedores
    {
        [Key]
        public int ProveedorId { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Nombre { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Direccion { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$",
        ErrorMessage = "El teléfono debe tener el formato (000) 000-0000")]
        public string? Telefono { get; set; } = null!;
        public Estados Estado { get; set; } = Estados.Activo;
    }
}
