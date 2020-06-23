using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Fluxor;
using System.Reflection;
using StateManagementWithFluxor.Services;

namespace StateManagementWithFluxor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") });

            // Add Fluxor
            builder.Services.AddFluxor(options => 
            {
                options.ScanAssemblies(Assembly.GetExecutingAssembly());
                options.UseReduxDevTools();
            });

            // Add custom application services
            builder.Services.AddScoped<StateFacade>();

            await builder.Build().RunAsync();
        }
    }
}
