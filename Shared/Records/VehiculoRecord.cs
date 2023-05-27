
namespace Aridio_Rent_A_Car.Shared.Records;

public class VehiculoRecord
{
    public VehiculoRecord()
    {
    }

    public VehiculoRecord(int id, string marca, int año, string modelo, string color, string numeroPlaca, decimal precioPorDia, string mensaje, bool activo, bool inactivo )
    {
        Id = id;
        Marca = marca;
        Año = año;
        Modelo = modelo;
        Color = color;
        NumeroPlaca = numeroPlaca;
        PrecioPorDia = precioPorDia;
        Mensaje = mensaje;
        Activo = activo;
        Inactivo = Inactivo;
       
    }

    public int Id { get; set; }
    public string Marca { get; set; } = null!;
    public int Año { get; set; }
    public string Modelo { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string NumeroPlaca { get; set; } = null!;
    public decimal PrecioPorDia { get; set; }
    public bool Activo { get; set; }
    public bool Inactivo { get; set; }
    public string Mensaje {get; set;} = null!;

    
}