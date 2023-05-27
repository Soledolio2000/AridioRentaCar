using System.ComponentModel.DataAnnotations;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Requests;

namespace Aridio_Rent_A_Car.Server.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int RolId { get; set; }
    public virtual UsuarioRol Roles { get; set; } = null!;

    public static Usuario Crear(UsuarioCreateRequest request)
    {
        return new Usuario(){
            Nombre = request.Nombre,
            Password = request.Password,
            RolId = request.RolId
        };
    }

    public void Modificar(UsuarioUpdateRequest request)
    {
        if(Nombre != request.Nombre)
            Nombre = request.Nombre;
        if(Password != request.Password)
            Password = request.Password;
        if(RolId != request.RolId)
            RolId = request.RolId;
    }

    public UsuarioRecord ToRecord()
    {
        return new UsuarioRecord(Id, Nombre, Password, RolId, Roles.ToRecord());
    }
}
