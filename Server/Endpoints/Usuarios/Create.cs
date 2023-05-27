using Aridio_Rent_A_Car.Shared.Wrapper;
using Aridio_Rent_A_Car.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Server.Models;
using Microsoft.EntityFrameworkCore;
using Aridio_Rent_A_Car.Shared.Routes;

namespace Aridio_Rent_A_Car.Server.Endpoints.Usuarios;

using Request = UsuarioCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(UsuarioRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var usuario = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
            if(usuario != null)
                return Respuesta.Fail($"Ya existe un usuario con el nombre '({request.Nombre})'.");
            #endregion
            usuario = Usuario.Crear(request);
            dbContext.Usuarios.Add(usuario);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(usuario.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}