
namespace Aridio_Rent_A_Car.Shared.Records;

public class ReservaRecord
{
    public ReservaRecord()
    {
    }

    public ReservaRecord(int id, DateTime fechaInicio, DateTime fechaFin, int vehiculoId, VehiculoRecord vehiculo, int clienteId, ClienteRecord cliente, int dias, decimal precioTotal, decimal preciorenta, string pago)
    {
        Id = id;
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
        VehiculoId = vehiculoId;
        Vehiculo = vehiculo;
        ClienteId = clienteId;
        Cliente = cliente;
        Dias = dias;
        PrecioTotal = precioTotal;
        precioRenta = preciorenta;
        Pago = pago;
    }

    public int Id { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int VehiculoId { get; set; }
    public virtual VehiculoRecord Vehiculo { get; set; } = null!;
    public int ClienteId { get; set; }
    public virtual ClienteRecord Cliente { get; set; } = null!;
    public int Dias { get; set; }
    public decimal PrecioTotal { get; set; }
    public decimal precioRenta { get; set; }
    public string Pago {get;set;} = null!; 
}
