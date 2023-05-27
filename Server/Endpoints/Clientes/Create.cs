using Aridio_Rent_A_Car.Shared.Wrapper;
using Aridio_Rent_A_Car.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Server.Models;
using Microsoft.EntityFrameworkCore;
using Aridio_Rent_A_Car.Shared.Routes;

namespace Aridio_Rent_A_Car.Server.Endpoints.Clientes;

using Request = ClienteCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(ClienteRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var cliente = await dbContext.Clientes.FirstOrDefaultAsync(c => c.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
            if(cliente != null)
                return Respuesta.Fail($"Ya existe un cliente con el nombre '({request.Nombre})'.");
            #endregion
            cliente = Cliente.Crear(request);
            dbContext.Clientes.Add(cliente);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(cliente.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}