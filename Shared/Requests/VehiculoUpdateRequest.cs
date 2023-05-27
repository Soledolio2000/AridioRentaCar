
using System.ComponentModel.DataAnnotations;

namespace Aridio_Rent_A_Car.Shared.Requests;

public class VehiculoUpdateRequest : VehiculoCreateRequest
{    
    [Required(ErrorMessage = "Ingrese un Id valido")    ]
    public int Id { get; set; }
}