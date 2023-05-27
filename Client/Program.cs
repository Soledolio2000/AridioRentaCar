using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Aridio_Rent_A_Car.Client;
using Aridio_Rent_A_Car.Client.Managers;


using Microsoft.AspNetCore.Components.Authorization;
using Aridio_Rent_A_Car.Client.Extensiones;
using Blazored.SessionStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IClienteManager, ClienteManager>();
builder.Services.AddScoped<IFormaDePagoManager, FormaDePagoManager>();
builder.Services.AddScoped<IReservaManager, ReservaManager>();
builder.Services.AddScoped<IUsuarioManager, UsuarioManager>();
builder.Services.AddScoped<IUsuarioRolManager, UsuarioRolManager>();
builder.Services.AddScoped<IVehiculoManager, VehiculoManager>();

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider,AutenticacionExtension>();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
