using Aridio_Rent_A_Car.Shared.Wrapper;
using Aridio_Rent_A_Car.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Server.Models;
using Microsoft.EntityFrameworkCore;
using Aridio_Rent_A_Car.Shared.Routes;

namespace Aridio_Rent_A_Car.Server.Endpoints.UsuariosRoles;

using Request = UsuarioRolCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(UsuarioRolRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var rol = await dbContext.UsuariosRoles.FirstOrDefaultAsync(r => r.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
            if(rol != null)
                return Respuesta.Fail($"Ya existe un rol con el nombre '({request.Nombre})'.");
            #endregion
            rol = UsuarioRol.Crear(request);
            dbContext.UsuariosRoles.Add(rol);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(rol.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}