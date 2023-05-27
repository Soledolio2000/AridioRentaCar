using Ardalis.ApiEndpoints;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aridio_Rent_A_Car.Server.Endpoints.Vehiculos;

using Respuesta = Result<int>;
using Request = VehiculoRouteManager;

public class Delete : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Delete(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpDelete(VehiculoRouteManager.Delete)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var vehiculo = await dbContext.Vehiculos.FindAsync(request.Id);
            if(vehiculo == null)
                return Respuesta.Fail($"No fue posible encontrar el vehiculo con el id '{request.Id}'");
            dbContext.Vehiculos.Remove(vehiculo);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(vehiculo.Id);
        }
        catch(Exception ex)
        {
            return Respuesta.Fail(ex.Message);
        }
    }
}