using Aridio_Rent_A_Car.Shared.Wrapper;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Client.Extensions;
using Aridio_Rent_A_Car.Shared.Requests;
using Aridio_Rent_A_Car.Client;
using Aridio_Rent_A_Car.Shared;
using System.Net.Http.Json;

namespace Aridio_Rent_A_Car.Client.Managers;

public interface IUsuarioManager
{
    Task<ResultList<UsuarioRecord>> GetAsync();
    Task<Result<int>> CreateAsync(UsuarioCreateRequest request);
    Task<Result<UsuarioRecord>> GetByIdAsync(int Id);
    Task<Result> DeleteAsync(int id);
}

public class UsuarioManager : IUsuarioManager
{
    private readonly HttpClient httpClient;

    public UsuarioManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<UsuarioRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(UsuarioRouteManager.BASE);
            var resultado = await response.ToResultList<UsuarioRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<UsuarioRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(UsuarioCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(UsuarioRouteManager.BASE,request);
        return await response.ToResult<int>();
    }

    public async Task<Result<UsuarioRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(UsuarioRouteManager.BuildRoute(Id));
        return await response.ToResult<UsuarioRecord>();
    }

    public async Task<Result> DeleteAsync(int id)
{
    try
    {
        var response = await httpClient.DeleteAsync(UsuarioRouteManager.BuildRoute(id));
        var resultado = await response.ToResult<UsuarioRecord>();
        return resultado;
    }
    catch (Exception e)
    {
        return Result.Fail(e.Message);
    }
}


}