
namespace Aridio_Rent_A_Car.Shared.Records;

public class UsuarioRecord
{
    public UsuarioRecord()
    {
    }

    public UsuarioRecord(int id, string nombre, string password, int rolId, UsuarioRolRecord roles)
    {
        Id = id;
        Nombre = nombre;
        Password = password;
        RolId = rolId;
        Roles = roles;
    }

    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int RolId { get; set; }
    public virtual UsuarioRolRecord Roles { get; set; } = null!;
}
