using Aridio_Rent_A_Car.Shared.Wrapper;
using Aridio_Rent_A_Car.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Server.Models;
using Microsoft.EntityFrameworkCore;
using Aridio_Rent_A_Car.Shared.Routes;

namespace Aridio_Rent_A_Car.Server.Endpoints.Vehiculos;

using Request = VehiculoCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(VehiculoRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var vehiculo = await dbContext.Vehiculos.FirstOrDefaultAsync(v => v.NumeroPlaca == request.NumeroPlaca,cancellationToken);
            if(vehiculo != null)
                return Respuesta.Fail($"Ya existe un vehiculo con numero de placa '({request.NumeroPlaca})'.");
            #endregion
            vehiculo = Vehiculo.Crear(request);
            dbContext.Vehiculos.Add(vehiculo);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(vehiculo.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}