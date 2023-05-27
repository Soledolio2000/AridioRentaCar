using System.ComponentModel.DataAnnotations;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Requests;

namespace Aridio_Rent_A_Car.Server.Models;

public class FormaDePago
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;

    public static FormaDePago Crear(FormaDePagoCreateRequest request)
    {
        return new FormaDePago(){
            Nombre = request.Nombre
        };
    }

    public void Modificar(FormaDePagoUpdateRequest request)
    {
        if(Nombre != request.Nombre)
            Nombre = request.Nombre;
    }

    public FormaDePagoRecord ToRecord()
    {
        return new FormaDePagoRecord(Id, Nombre);
    }
}
