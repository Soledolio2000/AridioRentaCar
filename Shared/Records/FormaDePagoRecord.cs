
namespace Aridio_Rent_A_Car.Shared.Records;

public class FormaDePagoRecord
{
    public FormaDePagoRecord()
    {
    }

    public FormaDePagoRecord(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }

    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
}
