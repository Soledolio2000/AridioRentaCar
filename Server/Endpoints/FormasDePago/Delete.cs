using Ardalis.ApiEndpoints;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aridio_Rent_A_Car.Server.Endpoints.FormasDePago;

using Respuesta = Result<int>;
using Request = FormaDePagoRouteManager;

public class Delete : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Delete(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpDelete(FormaDePagoRouteManager.Delete)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var forma = await dbContext.FormasDePago.FindAsync(request.Id);
            if(forma == null)
                return Respuesta.Fail($"No fue posible encontrar la forma de pago con el id '{request.Id}'");
            dbContext.FormasDePago.Remove(forma);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(forma.Id);
        }
        catch(Exception ex)
        {
            return Respuesta.Fail(ex.Message);
        }
    }
}