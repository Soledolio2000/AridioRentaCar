using Aridio_Rent_A_Car.Shared.Wrapper;
using Aridio_Rent_A_Car.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Server.Models;
using Microsoft.EntityFrameworkCore;
using Aridio_Rent_A_Car.Shared.Routes;

namespace Aridio_Rent_A_Car.Server.Endpoints.FormasDePago;

using Request = FormaDePagoCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(FormaDePagoRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var forma = await dbContext.FormasDePago.FirstOrDefaultAsync(f => f.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
            if(forma != null)
                return Respuesta.Fail($"Ya existe una forma de pago con el nombre '({request.Nombre})'.");
            #endregion
            forma = FormaDePago.Crear(request);
            dbContext.FormasDePago.Add(forma);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(forma.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}