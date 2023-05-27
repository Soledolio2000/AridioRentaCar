using Ardalis.ApiEndpoints;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aridio_Rent_A_Car.Server.Endpoints.Usuarios;

using Respuesta = Result<int>;
using Request = UsuarioRouteManager;

public class Delete : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Delete(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpDelete(UsuarioRouteManager.Delete)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var usuario = await dbContext.Usuarios.FindAsync(request.Id);
            if(usuario == null)
                return Respuesta.Fail($"No fue posible encontrar el usuario con el id '{request.Id}'");
            dbContext.Usuarios.Remove(usuario);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(usuario.Id);
        }
        catch(Exception ex)
        {
            return Respuesta.Fail(ex.Message);
        }
    }
}