using Ardalis.ApiEndpoints;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aridio_Rent_A_Car.Server.Endpoints.Reservas;

using Respuesta = Result<int>;
using Request = ReservaRouteManager;

public class Delete : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Delete(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpDelete(ReservaRouteManager.Delete)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var reserva = await dbContext.Reservas.FindAsync(request.Id);
            if(reserva == null)
                return Respuesta.Fail($"No fue posible encontrar la reserva con el id '{request.Id}'");
            dbContext.Reservas.Remove(reserva);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(reserva.Id);
        }
        catch(Exception ex)
        {
            return Respuesta.Fail(ex.Message);
        }
    }
}