using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanHome.Models;

public class OrdenCompra
{
    [Key]
    public int OrdenCompraId { get; set; }  

    [Required(ErrorMessage = "Debe seleccionar un proveedor")]
    public int ProveedorId { get; set; }

    public Proveedores? Proveedor { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; }  

    public Estados Estado { get; set; } = Estados.Activo;

    public string EstadoOrden { get; set; } = "Pendiente";

    public List<OrdenCompraDetalle> Detalles { get; set; } = new();
}