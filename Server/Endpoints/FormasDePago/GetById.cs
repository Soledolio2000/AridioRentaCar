using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Shared.Wrapper;

namespace Aridio_Rent_A_Car.Server.Endpoints.FormasDePago;

using Respuesta = Result<FormaDePagoRecord>;
using Request = FormaDePagoRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(FormaDePagoRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var forma = await dbContext.FormasDePago
            .Where(f => f.Id == request.Id)
            .Select(forma => forma.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(forma == null)
            return Respuesta.Fail($"No fue posible encontrar la forma de pago '{request.Id}'");

            return Respuesta.Sucess(forma);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}