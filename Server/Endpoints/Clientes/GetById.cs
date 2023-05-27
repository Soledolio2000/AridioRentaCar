using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Shared.Wrapper;

namespace Aridio_Rent_A_Car.Server.Endpoints.Clientes;

using Respuesta = Result<ClienteRecord>;
using Request = ClienteRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(ClienteRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            var cliente = await dbContext.Clientes
            .Where(c => c.Id == request.Id)
            .Select(cliente => cliente.ToRecord())
            .FirstOrDefaultAsync(cancellationToken);

            if(cliente == null)
            return Respuesta.Fail($"No fue posible encontrar el cliente con el id'{request.Id}'");

            return Respuesta.Sucess(cliente);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
    }
}