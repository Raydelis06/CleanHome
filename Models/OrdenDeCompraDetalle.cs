using System.ComponentModel.DataAnnotations;

namespace CleanHome.Models;

public class OrdenCompraDetalle
{
    [Key]
    public int OrdenCompraDetalleId { get; set; }

    [Required]
    public int OrdenCompraId { get; set; }

    public OrdenCompra? OrdenCompra { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un material")]
    public int MaterialId { get; set; }

    public Materiales? Material { get; set; }

    [Required(ErrorMessage = "La cantidad es obligatoria")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
    public decimal Precio { get; set; }
}
