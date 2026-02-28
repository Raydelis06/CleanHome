using System.ComponentModel.DataAnnotations;

namespace CleanHome.Models
{
    public class Materiales
    {
        [Key]
        public int MaterialId { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0,int.MaxValue, ErrorMessage = "El valor no puede ser menor que 0")]
        public int CantidadDisponible { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Unidad { get; set; } = null!;
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser mayor que 0")]
        public double Precio { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Este campo es obligatorio")]
        public int ProveedorId { get; set; }
        public Estados Estado { get; set; } = Estados.Activo;
    }
}
