using System.ComponentModel.DataAnnotations;

namespace CleanHome.Models
{
    public class TiposPropiedad
    {
        [Key]
        public int TipoPropiedadId { get; set; }

        [Required(ErrorMessage = "El nombre del tipo de propiedad es obligatorio")]
        public string Descripcion { get; set; } = null!; 

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Estados Estado { get; set; } = Estados.Activo;
    }
}
