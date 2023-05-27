
namespace Aridio_Rent_A_Car.Shared.Routes;

public class RouteApiBase
{
    public const string API = "/api";
    public int Id { get; set; }
    public const string IdParameter = "{Id:int}";
}

public class ClienteRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/clientes";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
    public const string Delete = $"{BASE}/eliminar/{IdParameter}";
    public static string BuildRouteDelete(int Id) => Delete.Replace(IdParameter,Id.ToString());
}

public class EstadoVehiculoRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/estadosvehiculos";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
    public const string Delete = $"{BASE}/eliminar/{IdParameter}";
    public static string BuildRouteDelete(int Id) => Delete.Replace(IdParameter,Id.ToString());
}

public class FormaDePagoRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/formasdepago";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
    public const string Delete = $"{BASE}/eliminar/{IdParameter}";
    public static string BuildRouteDelete(int Id) => Delete.Replace(IdParameter,Id.ToString());
}

public class ReservaRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/reservas";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
    public const string Delete = $"{BASE}/eliminar/{IdParameter}";
    public static string BuildRouteDelete(int Id) => Delete.Replace(IdParameter,Id.ToString());
}

public class TipoVehiculoRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/tiposdevehiculos";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
    public const string Delete = $"{BASE}/eliminar/{IdParameter}";
    public static string BuildRouteDelete(int Id) => Delete.Replace(IdParameter,Id.ToString());
}

public class UsuarioRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/usuarios";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
    public const string Delete = $"{BASE}/eliminar/{IdParameter}";
    public static string BuildRouteDelete(int Id) => Delete.Replace(IdParameter,Id.ToString());
}

public class UsuarioRolRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/roles";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
    public const string Delete = $"{BASE}/eliminar/{IdParameter}";
    public static string BuildRouteDelete(int Id) => Delete.Replace(IdParameter,Id.ToString());
}

public class VehiculoRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/vehiculos";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
    public const string Delete = $"{BASE}/eliminar/{IdParameter}";
    public static string BuildRouteDelete(int Id) => Delete.Replace(IdParameter,Id.ToString());
}