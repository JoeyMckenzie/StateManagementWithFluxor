using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Fluxor;
using System.Reflection;
using StateManagementWithFluxor.Services;
using System.Net.Mime;

namespace StateManagementWithFluxor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            // Add Fluxor
            builder.Services.AddFluxor(options =>
            {
                options.ScanAssemblies(Assembly.GetExecutingAssembly());
                options.UseReduxDevTools();
            });

            // Add custom application services
            builder.Services.AddScoped<StateFacade>();
            builder.Services.AddHttpClient<JsonPlaceholderApiService>(client =>
            {
                client.DefaultRequestHeaders.Add("Content-Control", $"{MediaTypeNames.Application.Json}; charset=utf-8");
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            });

            await builder.Build().RunAsync();
        }
    }
}
