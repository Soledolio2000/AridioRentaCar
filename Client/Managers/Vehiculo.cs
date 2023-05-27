using Aridio_Rent_A_Car.Shared.Wrapper;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Client.Extensions;
using Aridio_Rent_A_Car.Shared.Requests;
using System.Net.Http.Json;


namespace Aridio_Rent_A_Car.Client.Managers;

public interface IVehiculoManager
{
    Task<ResultList<VehiculoRecord>> GetAsync();
    Task<Result<int>> CreateAsync(VehiculoCreateRequest request);
    Task<Result<VehiculoRecord>> GetByIdAsync(int Id);
    Task<Result> DeleteAsync(int id);
}

public class VehiculoManager : IVehiculoManager
{
    private readonly HttpClient httpClient;

    public VehiculoManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }


    public async Task<ResultList<VehiculoRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(VehiculoRouteManager.BASE);
            var resultado = await response.ToResultList<VehiculoRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<VehiculoRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(VehiculoCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(VehiculoRouteManager.BASE,request);
        return await response.ToResult<int>();
    }

    public async Task<Result<VehiculoRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(VehiculoRouteManager.BuildRoute(Id));
        return await response.ToResult<VehiculoRecord>();
    }

    public async Task<Result> DeleteAsync(int id)
{
    try
    {
        var response = await httpClient.DeleteAsync(VehiculoRouteManager.BuildRoute(id));
        var resultado = await response.ToResult<VehiculoRecord>();
        return resultado;
    }
    catch (Exception e)
    {
        return Result.Fail(e.Message);
    }
}

}