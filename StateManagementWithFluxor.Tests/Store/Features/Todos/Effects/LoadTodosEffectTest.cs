using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluxor;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using StateManagementWithFluxor.Models.Todos.Dtos;
using StateManagementWithFluxor.Services;
using StateManagementWithFluxor.Store.Features.Todos.Actions.LoadTodos;
using StateManagementWithFluxor.Store.Features.Todos.Effects;
using Xunit;

namespace StateManagementWithFluxor.Tests.Store.Features.Todos.Effects
{
    public class LoadTodosEffectTest
    {
        private readonly Mock<IDispatcher> _dispatcher;
        private readonly Mock<IJsonPlaceholderApiService> _apiService;

        public LoadTodosEffectTest()
        {
            _dispatcher = new Mock<IDispatcher>();
            _apiService = new Mock<IJsonPlaceholderApiService>();
        }

        [Fact(DisplayName = "Verify the load todo success action is dispatched when the API returns successfully")]
        public async Task GivenRequestToLoadTodos_WhenApiReturnsSuccessful_DispatchesLoadTodosSuccessAction()
        {
            // Arrange
            var stubTodos = new[] { new TodoDto { Id = 1, Completed = true, Title = "test", UserId = 1 } };
            _apiService.Setup(m => m.GetAsync<IEnumerable<TodoDto>>(It.IsAny<string>()))
                .Returns(Task.FromResult(stubTodos.AsEnumerable()));

            // Act
            var effect = new LoadTodosEffect(NullLogger<LoadTodosEffect>.Instance, _apiService.Object);
            await effect.HandleAsync(new LoadTodosAction(), _dispatcher.Object);

            // Assert, verify the dispatcher action was called
            _dispatcher.Verify(m => m.Dispatch(It.IsAny<LoadTodosSuccessAction>()), Times.Once);
            _dispatcher.Verify(m => m.Dispatch(It.IsAny<LoadTodosFailureAction>()), Times.Never);
        }

        [Fact(DisplayName = "Verify the load todo failure action is dispatched when the API returns unsuccessfully")]
        public async Task GivenRequestToLoadTodos_WhenApiServiceThrowsException_DispatchesLoadTodosFailureAction()
        {
            // Arrange
            _apiService.Setup(m => m.GetAsync<IEnumerable<TodoDto>>(It.IsAny<string>()))
                .Throws<HttpRequestException>();

            // Act
            var effect = new LoadTodosEffect(NullLogger<LoadTodosEffect>.Instance, _apiService.Object);
            await effect.HandleAsync(new LoadTodosAction(), _dispatcher.Object);

            // Assert, verify the dispatcher action was called
            _dispatcher.Verify(m => m.Dispatch(It.IsAny<LoadTodosSuccessAction>()), Times.Never);
            _dispatcher.Verify(m => m.Dispatch(It.IsAny<LoadTodosFailureAction>()), Times.Once);
        }
    }
}
