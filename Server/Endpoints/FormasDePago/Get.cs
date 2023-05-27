
using Ardalis.ApiEndpoints;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aridio_Rent_A_Car.Server.Endpoints.FormasDePago;

using Respuesta = ResultList<FormaDePagoRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Get(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(FormaDePagoRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var formas = await dbContext.FormasDePago.Select(forma => forma.ToRecord())
        .ToListAsync(cancellationToken);
            return Respuesta.Success(formas);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}