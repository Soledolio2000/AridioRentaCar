using System.ComponentModel.DataAnnotations;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Requests;

namespace Aridio_Rent_A_Car.Server.Models;

public class Reserva
{
    [Key]
    public int Id { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int VehiculoId { get; set; }
    public virtual Vehiculo Vehiculo { get; set; } = null!;
    public int ClienteId { get; set; }
    public virtual Cliente Cliente { get; set; } = null!;
    public int Dias { get; set; }
    public decimal PrecioTotal { get; set; }
    public decimal precioRenta { get; set; }
    public int FormaDePagoId { get; set; }
    public virtual FormaDePago FormaDePago { get; set; } = null!;

    public static Reserva Crear(ReservaCreateRequest request)
    {
        return new Reserva(){
            FechaInicio = request.FechaInicio,
            FechaFin = request.FechaFin,
            VehiculoId = request.VehiculoId,
            ClienteId = request.ClienteId,
            Dias = request.Dias,
            PrecioTotal = request.PrecioTotal,
            precioRenta= request.precioRenta,
            FormaDePagoId = request.FormaDePagoId,
        };
    }

    public void Modificar(ReservaUpdateRequest request)
    {
        if(FechaInicio != request.FechaInicio)
            FechaInicio = request.FechaInicio;
        if(FechaFin != request.FechaFin)
            FechaFin = request.FechaFin;
        if(VehiculoId != request.VehiculoId)
            VehiculoId = request.VehiculoId;
        if(ClienteId != request.ClienteId)
            ClienteId = request.ClienteId;
        if(Dias != request.Dias)
            Dias = request.Dias;
        if(PrecioTotal != request.PrecioTotal)
            PrecioTotal = request.PrecioTotal;
        if(precioRenta != request.precioRenta)
            precioRenta = request.precioRenta;
        if(FormaDePagoId != request.FormaDePagoId)
            FormaDePagoId = request.FormaDePagoId;
    }

    public ReservaRecord ToRecord()
    {
        return new ReservaRecord(Id, FechaInicio, FechaFin, VehiculoId, Vehiculo.ToRecord(), ClienteId, Cliente.ToRecord(), Dias, PrecioTotal, precioRenta, FormaDePagoId, FormaDePago.ToRecord());
    }
}
