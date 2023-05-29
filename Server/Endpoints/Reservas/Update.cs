using Aridio_Rent_A_Car.Shared.Wrapper;
using Aridio_Rent_A_Car.Shared.Requests;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Aridio_Rent_A_Car.Server.Context;
using Aridio_Rent_A_Car.Server.Models;
using Microsoft.EntityFrameworkCore;
using Aridio_Rent_A_Car.Shared.Routes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aridio_Rent_A_Car.Server.Endpoints.Reservas
{
    using Request = ReservaUpdateRequest;
    using Respuesta = Result<int>;

    public class Update : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
    {
        private readonly IMyDbContext dbContext;

        public Update(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPut(ReservaRouteManager.BASE + "/{id}")]
        public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
        {
            try
            {
                var reserva = await dbContext.Reservas.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);
                if (reserva == null)
                {
                    return Respuesta.Fail($"No se encontró la reserva con ID '{request.Id}'.");
                }

                // Actualizar las propiedades de la reserva con los valores del request
                reserva.FechaInicio = request.FechaInicio;
                reserva.FechaFin = request.FechaFin;
                reserva.VehiculoId = request.VehiculoId;
                reserva.ClienteId = request.ClienteId;
                reserva.Dias = request.Dias;
                reserva.PrecioTotal = request.PrecioTotal;
                reserva.precioRenta = request.precioRenta;
                reserva.Pago = request.Pago;

                // Guardar los cambios en la base de datos
                await dbContext.SaveChangesAsync(cancellationToken);

                // Retornar el resultado exitoso con el ID de la reserva actualizada
                return Respuesta.Sucess(reserva.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al guardar los cambios de entidad: " + e.Message);
                return Respuesta.Fail("Error al guardar los cambios de entidad. Consulta el registro para obtener más detalles.");
            }
        }
    }
}
