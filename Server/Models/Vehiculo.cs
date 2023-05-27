using System.ComponentModel.DataAnnotations;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Requests;

namespace Aridio_Rent_A_Car.Server.Models;

public class Vehiculo
{
    [Key]
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

    

    public static Vehiculo Crear(VehiculoCreateRequest request)
    {
        return new Vehiculo(){
            Marca = request.Marca,
            Año = request.Año,
            Modelo = request.Modelo,
            Color = request.Color,
            NumeroPlaca = request.NumeroPlaca,
            PrecioPorDia = request.PrecioPorDia,
            Mensaje = request.Mensaje,
            Activo = request.Activo,
            Inactivo = request.Inactivo

           
        };
    }

    public void Modificar(VehiculoUpdateRequest request)
    {
        if(Marca != request.Marca)
            Marca = request.Marca;
        if(Año != request.Año)
            Año = request.Año;
        if(Modelo != request.Modelo)
            Modelo = request.Modelo;
        if(Color != request.Color)
            Color = request.Color;
        if(NumeroPlaca != request.NumeroPlaca)
            NumeroPlaca = request.NumeroPlaca;
        if(PrecioPorDia != request.PrecioPorDia)
            PrecioPorDia = request.PrecioPorDia;
        if(Mensaje != request.Mensaje)
            Mensaje = request.Mensaje;
        if(Activo != request.Activo )
            Activo  = request.Activo ;
        if(Inactivo != request.Inactivo )
            Inactivo  = request.Inactivo ;

        
    }

    public VehiculoRecord ToRecord()
    {
        return new VehiculoRecord(Id, Marca, Año, Modelo, Color, NumeroPlaca, PrecioPorDia, Mensaje, Activo, Inactivo);
    }
}
