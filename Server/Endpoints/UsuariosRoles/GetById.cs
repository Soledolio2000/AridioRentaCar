using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Shared.Wrapper;

namespace Aridio_Rent_A_Car.Server.Endpoints.UsuariosRoles;

using Respuesta = Result<UsuarioRolRecord>;
using Request = UsuarioRolRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(UsuarioRolRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var rol = await dbContext.UsuariosRoles
            .Where(r => r.Id == request.Id)
            .Select(rol => rol.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(rol == null)
            return Respuesta.Fail($"No fue posible encontrar el rol con el id '{request.Id}'");

            return Respuesta.Sucess(rol);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}