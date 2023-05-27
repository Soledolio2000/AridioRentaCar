using Aridio_Rent_A_Car.Shared.Wrapper;
using Aridio_Rent_A_Car.Shared.Records;
using Aridio_Rent_A_Car.Shared.Routes;
using Aridio_Rent_A_Car.Client.Extensions;
using Aridio_Rent_A_Car.Shared.Requests;
using System.Net.Http.Json;

namespace Aridio_Rent_A_Car.Client.Managers;

public interface IFormaDePagoManager
{
    Task<ResultList<FormaDePagoRecord>> GetAsync();
    Task<Result<int>> CreateAsync(FormaDePagoCreateRequest request);
    Task<Result<FormaDePagoRecord>> GetByIdAsync(int Id);
    Task<Result> DeleteAsync(int id);
}

public class FormaDePagoManager : IFormaDePagoManager
{
    private readonly HttpClient httpClient;

    public FormaDePagoManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<FormaDePagoRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(FormaDePagoRouteManager.BASE);
            var resultado = await response.ToResultList<FormaDePagoRecord>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<FormaDePagoRecord>.Fail(e.Message);
        }
    }

    public async Task<Result<int>> CreateAsync(FormaDePagoCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(FormaDePagoRouteManager.BASE,request);
        return await response.ToResult<int>();
    }

    public async Task<Result<FormaDePagoRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(FormaDePagoRouteManager.BuildRoute(Id));
        return await response.ToResult<FormaDePagoRecord>();
    }

    public async Task<Result> DeleteAsync(int id)
{
    try
    {
        var response = await httpClient.DeleteAsync(FormaDePagoRouteManager.BuildRoute(id));
        var resultado = await response.ToResult<FormaDePagoRecord>();
        return resultado;
    }
    catch (Exception e)
    {
        return Result.Fail(e.Message);
    }
}

}