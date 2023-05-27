using Ardalis.ApiEndpoints;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aridio_Rent_A_Car.Server.Endpoints.UsuariosRoles;

using Respuesta = Result<int>;
using Request = UsuarioRolRouteManager;

public class Delete : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Delete(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpDelete(UsuarioRolRouteManager.Delete)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var rol = await dbContext.UsuariosRoles.FindAsync(request.Id);
            if(rol == null)
                return Respuesta.Fail($"No fue posible encontrar el rol con el id '{request.Id}'");
            dbContext.UsuariosRoles.Remove(rol);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(rol.Id);
        }
        catch(Exception ex)
        {
            return Respuesta.Fail(ex.Message);
        }
    }
}