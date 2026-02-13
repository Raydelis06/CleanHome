using System.ComponentModel.DataAnnotations;
namespace CleanHome.Models;


public class Clientes
{

    [Key]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Cedula { get; set; } = null;

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Nombre { get; set; } = null;

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Direccion { get; set; } = null;

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Telefono { get; set; } = null;


}

