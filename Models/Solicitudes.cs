using System;
using System.ComponentModel.DataAnnotations;

namespace CleanHome.Models
{
    public class SolicitudDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El cliente es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un cliente valido.") ]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(300, ErrorMessage = "Máximo 300 caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public EstadoSolicitud Estado { get; set; }
        public Estados EstaInactiva { get; set; }
    }
}