
namespace Aridio_Rent_A_Car.Shared.Records;

public class ClienteRecord
{
    public ClienteRecord()
    {
    }

    public ClienteRecord(int id, string nombre, string direccion, string telefono, string nacionalidad, string cedula, string ocupacion, string pasaporte, string licencia, DateTime fechaExpiracionLicencia)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Nacionalidad = nacionalidad;
        Cedula = cedula;
        Ocupacion = ocupacion;
        Pasaporte = pasaporte;
        Licencia = licencia;
        FechaExpiracionLicencia = fechaExpiracionLicencia;
    }

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
}
