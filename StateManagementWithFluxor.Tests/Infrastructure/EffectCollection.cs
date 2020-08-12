using Xunit;

namespace StateManagementWithFluxor.Tests.Infrastructure
{
    [CollectionDefinition(nameof(FluxorEffectFixture))]
    public class EffectCollection : ICollectionFixture<FluxorEffectFixture>
    {
    }
}
