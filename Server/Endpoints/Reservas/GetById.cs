using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Shared.Wrapper;

namespace Aridio_Rent_A_Car.Server.Endpoints.Reservas;

using Respuesta = Result<ReservaRecord>;
using Request = ReservaRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(ReservaRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var reserva = await dbContext.Reservas
            .Where(r => r.Id == request.Id)
            .Select(reserva => reserva.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(reserva == null)
            return Respuesta.Fail($"No fue posible encontrar la reserva '{request.Id}'");

            return Respuesta.Sucess(reserva);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}