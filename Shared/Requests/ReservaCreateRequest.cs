
using System.ComponentModel.DataAnnotations;

namespace Aridio_Rent_A_Car.Shared.Requests;

public class ReservaCreateRequest
{
    [Required(ErrorMessage = "Ingrese una fecha valida")]
    public DateTime FechaInicio { get; set; }
    [Required(ErrorMessage = "Ingrese una fecha valida")]
    public DateTime FechaFin { get; set; }
    [Required(ErrorMessage = "Ingrese un Id valido")]
    public int VehiculoId { get; set; }
    [Required(ErrorMessage = "Ingrese un Id valido")]
    
    public int ClienteId { get; set; }
    [Required(ErrorMessage = "Ingrese un valor valida")]
    public int Dias { get; set; }
    public decimal PrecioTotal { get; set; }
    public decimal precioRenta { get; set; }
    public string Pago {get; set;} = null!;
}
