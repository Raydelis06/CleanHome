
using System.ComponentModel.DataAnnotations;

namespace CleanHome.Models
{
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string CodigoFactura { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime Fecha { get; set; } = DateTime.Today;
        
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public double MontoTotal { get; set; }
        public EstadosFactura EstadoFactura { get; set; } = EstadosFactura.Pendiente;   
        public Estados Estado { get; set; } = Estados.Activo;

        public int MaterialId { get; set; }
        public int Cantidad { get; set; }

    }
}
