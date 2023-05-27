using Aridio_Rent_A_Car.Shared.Wrapper;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Client.Extensions;
using Aridio_Rent_A_Car.Shared.Requests;
using System.Net.Http.Json;

namespace Aridio_Rent_A_Car.Client.Managers;

public interface IUsuarioRolManager
{
    Task<ResultList<UsuarioRolRecord>> GetAsync();
    Task<Result<int>> CreateAsync(UsuarioRolCreateRequest request);
    Task<Result<UsuarioRolRecord>> GetByIdAsync(int Id);
    Task<Result> DeleteAsync(int id);
}

public class UsuarioRolManager : IUsuarioRolManager
{
    private readonly HttpClient httpClient;

    public UsuarioRolManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<UsuarioRolRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(UsuarioRolRouteManager.BASE);
            var resultado = await response.ToResultList<UsuarioRolRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<UsuarioRolRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(UsuarioRolCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(UsuarioRolRouteManager.BASE,request);
        return await response.ToResult<int>();
    }

    public async Task<Result<UsuarioRolRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(UsuarioRolRouteManager.BuildRoute(Id));
        return await response.ToResult<UsuarioRolRecord>();
    }

    public async Task<Result> DeleteAsync(int id)
{
    try
    {
        var response = await httpClient.DeleteAsync(UsuarioRolRouteManager.BuildRoute(id));
        var resultado = await response.ToResult<UsuarioRolRecord>();
        return resultado;
    }
    catch (Exception e)
    {
        return Result.Fail(e.Message);
    }
}

}