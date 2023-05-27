
using System.ComponentModel.DataAnnotations;

namespace Aridio_Rent_A_Car.Shared.Requests;

public class UsuarioCreateRequest
{
    [
        Required(ErrorMessage = "Ingrese un nombre valido"),
        MinLength(5, ErrorMessage = "El nombre debe poseer al menos 5 caracteres"),
        MaxLength(100, ErrorMessage = "El nombre debe poseer como maximo 100 caracteres")
    ]
    public string Nombre { get; set; } = null!;
    [
        Required(ErrorMessage = "Ingrese una contraseña valida"),
        MinLength(6, ErrorMessage = "La contraseña debe poseer minimo 6 caracteres")
    ]
    public string Password { get; set; } = null!;
    [Required(ErrorMessage = "Ingrese un valor valido")]
    public int RolId { get; set; }
}
