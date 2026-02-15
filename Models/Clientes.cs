using System.ComponentModel.DataAnnotations;
namespace CleanHome.Models;


public class Clientes
{

    [Key]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [RegularExpression(@"^\d{3}-\d{7}-\d{1}$",
    ErrorMessage = "La cédula debe tener el formato 000-0000000-0")]
    public string Cedula { get; set; } = null;

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Nombre { get; set; } = null;

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Direccion { get; set; } = null;

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$",
    ErrorMessage = "El teléfono debe tener el formato (000) 000-0000")]
    public string Telefono { get; set; } = null;
    public Estados Estado { get; set; } = Estados.Activo;

}

