using System.ComponentModel.DataAnnotations;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Requests;

namespace Aridio_Rent_A_Car.Server.Models;

public class Cliente
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public string Nacionalidad { get; set; } = null!;
    public string Cedula { get; set; } = null!;
    public string Ocupacion { get; set; } = null!;
    public string Pasaporte { get; set; } = null!;
    public string Licencia { get; set; } = null!;
    public DateTime FechaExpiracionLicencia { get; set; }

    public static Cliente Crear(ClienteCreateRequest request)
    {
        return new Cliente(){
            Nombre = request.Nombre,
            Direccion = request.Direccion,
            Telefono = request.Telefono,
            Nacionalidad = request.Nacionalidad,
            Cedula = request.Cedula,
            Ocupacion = request.Ocupacion,
            Pasaporte = request.Pasaporte,
            Licencia = request.Licencia,
            FechaExpiracionLicencia = request.FechaExpiracionLicencia
        };
    }

    public void Modificar(ClienteUpdateRequest request)
    {
        if(Nombre != request.Nombre)
            Nombre = request.Nombre;
        if(Direccion != request.Direccion)
           Direccion = request.Direccion;
        if(Telefono != request.Telefono)
           Telefono = request.Telefono;
        if(Nacionalidad != request.Nacionalidad)
           Nacionalidad = request.Nacionalidad;
        if(Cedula != request.Cedula)
           Cedula = request.Cedula;
        if(Ocupacion != request.Ocupacion)
           Ocupacion = request.Ocupacion;
        if(Pasaporte != request.Pasaporte)
           Pasaporte = request.Pasaporte;
        if(Licencia != request.Licencia)
           Licencia = request.Licencia;
        if(FechaExpiracionLicencia != request.FechaExpiracionLicencia)
           FechaExpiracionLicencia = request.FechaExpiracionLicencia;
    }

    public ClienteRecord ToRecord()
    {
      return new ClienteRecord(Id, Nombre, Direccion, Telefono, Nacionalidad, Cedula, Ocupacion, Pasaporte, Licencia, FechaExpiracionLicencia);
    }
}