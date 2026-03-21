using System.ComponentModel.DataAnnotations;

namespace CleanHome.Models
{
    public class Propiedades
    {
        [Key]
        public int PropiedadId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un cliente propietario")]
        public int ClienteId { get; set; } 

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de propiedad")]
        public int TipoPropiedadId { get; set; }  

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Direccion { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor no puede ser menor que 0")]
        public int CantidadHabitaciones { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "El tamaño debe ser mayor que 0")]
        public double TamañoMetrosCuadrados { get; set; }

        public Estados Estado { get; set; } = Estados.Activo;
    }
}
