
using System.ComponentModel.DataAnnotations;

namespace Aridio_Rent_A_Car.Shared.Requests;

public class ClienteCreateRequest
{
    [
        Required(ErrorMessage = "Ingrese un nombre valido"),
        MinLength(5, ErrorMessage = "El nombre debe poseer al menos 5 caracteres"),
        MaxLength(100, ErrorMessage = "El nombre debe poseer como maximo 100 caracteres")
    ]
    public string Nombre { get; set; } = null!;
    [
        Required(ErrorMessage = "Ingrese una direccion valido")
    ]
    public string Direccion { get; set; } = null!;
    [
        Required(ErrorMessage = "Ingrese un telefono valido"),
    ]
    public string Telefono { get; set; } = null!;
    [
        Required(ErrorMessage = "Ingrese una nacionalidad valida")
    ]
    public string Nacionalidad { get; set; } = null!;
    [
        Required(ErrorMessage = "Ingrese una cedula valido"),
        MinLength(11, ErrorMessage = "Ingrese una cedula valido"),
        MaxLength(11, ErrorMessage = "Ingrese una cedula valido")
    ]
    public string Cedula { get; set; } = null!;
    public string Ocupacion { get; set; } = null!;
    public string Pasaporte { get; set; } = null!;
    
    [
        Required(ErrorMessage = "Ingrese un numero de licencia valido")
    ]
    public string Licencia { get; set; } = null!;
    [
        Required(ErrorMessage = "Ingrese una fecha valida")
    ]
    public DateTime FechaExpiracionLicencia { get; set; }
}
