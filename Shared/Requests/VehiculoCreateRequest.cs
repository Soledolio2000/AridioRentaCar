
using System.ComponentModel.DataAnnotations;

namespace Aridio_Rent_A_Car.Shared.Requests;

public class VehiculoCreateRequest
{
    [Required(ErrorMessage = "Ingrese la marca")]
    public string Marca { get; set; } = null!;
    [Required(ErrorMessage = "Ingrese el año")]
    public int Año { get; set; }
    [Required(ErrorMessage = "Ingrese un valor valido")]
    public string Modelo { get; set; } = null!;
    public string Color { get; set; } = null!;
    [Required(ErrorMessage = "Ingrese una placa valida")]
    public string NumeroPlaca { get; set; } = null!;
    [Required(ErrorMessage = "Ingrese la marca")]
    public decimal PrecioPorDia { get; set; }

    public string Mensaje {get; set;} = null!;

    public bool Activo { get; set; }
    public bool Inactivo { get; set; }
   
}
