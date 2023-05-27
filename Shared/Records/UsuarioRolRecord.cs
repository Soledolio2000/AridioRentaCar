
namespace Aridio_Rent_A_Car.Shared.Records;

public class UsuarioRolRecord
{
    public UsuarioRolRecord()
    {
    }

    public UsuarioRolRecord(int id, string nombre, bool permisoParaCrear, bool permisoParaEditar, bool permisoParaEliminar)
    {
        Id = id;
        Nombre = nombre;
        this.PermisoParaCrear = permisoParaCrear;
        this.PermisoParaEditar = permisoParaEditar;
        this.PermisoParaEliminar = permisoParaEliminar;
    }

    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    
    public bool PermisoParaCrear { get; set; }
    public bool PermisoParaEditar{ get; set; }
    public bool PermisoParaEliminar{ get; set; }
}
