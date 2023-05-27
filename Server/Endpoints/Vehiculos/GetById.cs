using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Shared.Wrapper;

namespace Aridio_Rent_A_Car.Server.Endpoints.Vehiculos;

using Respuesta = Result<VehiculoRecord>;
using Request = VehiculoRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(VehiculoRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var vehiculo = await dbContext.Vehiculos
            .Where(v => v.Id == request.Id)
            .Select(vehiculo => vehiculo.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(vehiculo == null)
            return Respuesta.Fail($"No fue posible encontrar el vehiculo con el id '{request.Id}'");

            return Respuesta.Sucess(vehiculo);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }

}