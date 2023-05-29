using Aridio_Rent_A_Car.Shared.Wrapper;
using Aridio_Rent_A_Car.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Server.Models;
using Microsoft.EntityFrameworkCore;
using Aridio_Rent_A_Car.Shared.Routes;

namespace Aridio_Rent_A_Car.Server.Endpoints.Reservas;

using Request = ReservaCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(ReservaRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try{
            #region Validaciones
            var reserva = await dbContext.Reservas.FirstOrDefaultAsync(r => r.VehiculoId == request.VehiculoId && ((r.FechaInicio >= request.FechaInicio && r.FechaInicio <= request.FechaFin) || (r.FechaFin >= request.FechaInicio && r.FechaFin <= request.FechaFin)), cancellationToken);
            if (reserva != null)
            {
                return Respuesta.Fail($"El vehículo con ID '{request.VehiculoId}' ya está reservado en el rango de fechas especificado.");
            }

            #endregion
            reserva = Reserva.Crear(request);
            dbContext.Reservas.Add(reserva);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Sucess(reserva.Id);
        }
        catch(Exception e){
            return Respuesta.Fail(e.InnerException.Message);
        }
    }
}