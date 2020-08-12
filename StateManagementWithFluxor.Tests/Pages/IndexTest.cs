using Bunit;
using StateManagementWithFluxor.Pages;
using Xunit;

namespace StateManagementWithFluxor.Tests.Pages
{
    public class IndexTest : TestContext
    {
        [Fact(DisplayName = "Verify the initial landing page markup")]
        public void GivenInitialPageLoad_WhenComponentHasRendered_DisplaysCorrectMarkup()
        {
            // Arrange 
            const string expectedHtml = @"
<h1>Hello, world!</h1>

Welcome to your new app.";

            // Act
            var component = RenderComponent<Index>();

            // Assert
            component.MarkupMatches(expectedHtml);
        }
    }
}
