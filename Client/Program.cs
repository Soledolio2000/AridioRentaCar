using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Aridio_Rent_A_Car.Client;
using Aridio_Rent_A_Car.Client.Managers;

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

await builder.Build().RunAsync();
