
using Aridio_Rent_A_Car.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Aridio_Rent_A_Car.Server.Context;

public interface IMyDbContext

{
    DbSet<Cliente> Clientes { get; set; }
    DbSet<Reserva> Reservas { get; set; }
    DbSet<Usuario> Usuarios { get; set; }
    DbSet<UsuarioRol> UsuariosRoles { get; set; }
    DbSet<Vehiculo> Vehiculos { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class MyDbContext : DbContext, IMyDbContext
{
    private readonly IConfiguration config;

    public MyDbContext(IConfiguration _config)
    {
        config = _config;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(config.GetConnectionString("AridioRentACar"));
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    #region Tablas de mi base de datos
    public DbSet<Cliente> Clientes { get; set; } = null!;
    public DbSet<Reserva> Reservas { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<UsuarioRol> UsuariosRoles { get; set; } = null!;
    public DbSet<Vehiculo> Vehiculos { get; set; } = null!;

    #endregion
}