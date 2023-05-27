using Aridio_Rent_A_Car.Shared.Wrapper;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Client.Extensions;
using Aridio_Rent_A_Car.Shared.Requests;
using System.Net.Http.Json;

namespace Aridio_Rent_A_Car.Client.Managers;

public interface IClienteManager
{
    Task<ResultList<ClienteRecord>> GetAsync();
    Task<Result<int>> CreateAsync(ClienteCreateRequest request);
    Task<Result<ClienteRecord>> GetByIdAsync(int Id);
    Task<Result> DeleteAsync(int id);
}

public class ClienteManager : IClienteManager
{
    private readonly HttpClient httpClient;

    public ClienteManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<ClienteRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(ClienteRouteManager.BASE);
            var resultado = await response.ToResultList<ClienteRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<ClienteRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(ClienteCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(ClienteRouteManager.BASE,request);
        return await response.ToResult<int>();
    }

    public async Task<Result<ClienteRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(ClienteRouteManager.BuildRoute(Id));
        return await response.ToResult<ClienteRecord>();
    }

    public async Task<Result> DeleteAsync(int id)
{
    try
    {
        var response = await httpClient.DeleteAsync(ClienteRouteManager.BuildRoute(id));
        var resultado = await response.ToResult<ClienteRecord>();
        return resultado;
    }
    catch (Exception e)
    {
        return Result.Fail(e.Message);
    }
}

}