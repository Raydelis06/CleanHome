using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanHome.Models
{
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string CodigoFactura { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime Fecha { get; set; } = DateTime.Today;

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoTotal { get; set; }

        public EstadosFactura EstadoFactura { get; set; } = EstadosFactura.Pendiente;   
        public Estados Estado { get; set; } = Estados.Activo;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int ClienteId { get; set; }

        public Clientes? Cliente { get; set; }

        public List<FacturaDetalle> Detalles { get; set; } = new();
        public List<FacturaServicio> Servicios { get; set; } = new();
    }
}
