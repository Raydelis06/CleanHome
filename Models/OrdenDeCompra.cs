using CleanHome.Components.OrdenDeCompra;
using System.ComponentModel.DataAnnotations;

namespace CleanHome.Models;

public class OrdenCompra
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un proveedor")]
    public int ProveedorId { get; set; }

    public Proveedores? Proveedor { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor que cero")]
    public decimal Total { get; set; }

    public Estados Estado { get; set; } = Estados.Activo;

    [Required]
    public string EstadoOrden { get; set; } = "Pendiente";

    public List<OrdenCompraDetalle> Detalles { get; set; } = new();
    public int OrdenCompraId { get; internal set; }
}