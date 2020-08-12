using System;
using Fluxor;
using Moq;
using StateManagementWithFluxor.Services;

namespace StateManagementWithFluxor.Tests.Infrastructure
{
    public class FluxorEffectFixture
    {
        public FluxorEffectFixture()
        {
            // Add a mock dispatcher, it's an internal detail so we won't be mocking its behavior directly
            MockDispatcher = new Mock<IDispatcher>();

            // Add a mock API service instance we'll be able to test with
            MockApiService = new Mock<IJsonPlaceholderApiService>();
        }

        public Mock<IJsonPlaceholderApiService> MockApiService { get; }

        public Mock<IDispatcher> MockDispatcher { get; }
    }
}
