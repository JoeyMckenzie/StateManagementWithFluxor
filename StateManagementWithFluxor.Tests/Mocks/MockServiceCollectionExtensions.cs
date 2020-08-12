using System;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace StateManagementWithFluxor.Tests.Mocks
{
    public static class MockServiceCollectionExtensions
    {
        public static void AddMockNavigationManager(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<NavigationManager, MockNavigationManager>();
        }
    }
}
