using Aridio_Rent_A_Car.Shared.Wrapper;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Client.Extensions;
using Aridio_Rent_A_Car.Shared.Requests;
using System.Net.Http.Json;

namespace Aridio_Rent_A_Car.Client.Managers;

public interface IReservaManager
{
    Task<ResultList<ReservaRecord>> GetAsync();
    Task<Result<int>> CreateAsync(ReservaCreateRequest request);
    Task<Result<ReservaRecord>> GetByIdAsync(int Id);
    Task<Result> DeleteAsync(int id);
}

public class ReservaManager : IReservaManager
{
    private readonly HttpClient httpClient;

    public ReservaManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<ReservaRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(ReservaRouteManager.BASE);
            var resultado = await response.ToResultList<ReservaRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<ReservaRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(ReservaCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(ReservaRouteManager.BASE,request);
        return await response.ToResult<int>();
    }

    public async Task<Result<ReservaRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(ReservaRouteManager.BuildRoute(Id));
        return await response.ToResult<ReservaRecord>();
    }

    public async Task<Result> DeleteAsync(int id)
{
    try
    {
        var response = await httpClient.DeleteAsync(ReservaRouteManager.BuildRoute(id));
        var resultado = await response.ToResult<ReservaRecord>();
        return resultado;
    }
    catch (Exception e)
    {
        return Result.Fail(e.Message);
    }
}

}