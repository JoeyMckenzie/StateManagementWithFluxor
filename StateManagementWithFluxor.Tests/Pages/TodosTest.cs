using System;
using System.Linq;
using Bunit;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shouldly;
using StateManagementWithFluxor.Models.Todos.Dtos;
using StateManagementWithFluxor.Pages;
using StateManagementWithFluxor.Services;
using StateManagementWithFluxor.Store.State;
using StateManagementWithFluxor.Tests.Mocks;
using Xunit;

namespace StateManagementWithFluxor.Tests.Pages
{
    public class TodosTest : TestContext
    {
        private readonly Mock<IStateFacade> _mockFacade;
        private readonly Mock<IJsonPlaceholderApiService> _mockApiService;
        private readonly Mock<IState<TodosState>> _mockState;

        public TodosTest()
        {
            _mockFacade = new Mock<IStateFacade>();
            _mockApiService = new Mock<IJsonPlaceholderApiService>();
            _mockState = new Mock<IState<TodosState>>();
            Services.AddSingleton(_mockFacade.Object);
            Services.AddSingleton(_mockApiService.Object);
            Services.AddSingleton(_mockState.Object);
            Services.AddMockNavigationManager();
        }

        [Fact(DisplayName = "Verify on page initialization the loading text is displayed")]
        public void GivenInitialPageLoad_WhenComponentIsRendering_DisplaysLoadingText()
        {
            // Arrange
            var initialState = new TodosState(true, null, null, null);
            _mockState.Setup(m => m.Value).Returns(initialState);
            const string expectedHtml = @"
<h3 class='text-center mb-3'>Todos</h3>

<div class='d-flex flex-row justify-content-center'>
    <div class='spinner-border' role='status'>
        <span class='sr-only'>Loading...</span>
    </div>
</div>";

            // Act
            var component = RenderComponent<Todos>();

            // Assert
            component.MarkupMatches(expectedHtml);
        }

        [Fact(DisplayName = "Verify the load todos action is dispatched when no todos are available in state")]
        public void GivenInitialPageLoad_WhenNoTodosExistInState_DispatchesLoadTodosFacadeAction()
        {
            // Arrange
            var initialState = new TodosState(true, null, null, null);
            _mockState.Setup(m => m.Value).Returns(initialState);

            // Act
            var component = RenderComponent<Todos>();

            // Assert
            _mockFacade.Verify(m => m.LoadTodos(), Times.Once);
        }

        [Fact(DisplayName = "Verify the error markup renders correctly when the state contains errors")]
        public void GivenInitialPageLoad_WhenErrorsExistInState_DisplaysCorrectMarkup()
        {
            // Arrange
            var state = new TodosState(false, "Oh no!", null, null);
            _mockState.Setup(m => m.Value).Returns(state);
            const string expectedHtml = @"
<h3 class='text-center mb-3'>Todos</h3>

<div class='d-flex flex-column align-items-center'>
    <span class='py-2'>Whoops! Looks like an issue occurred loading todos :(</span>
    <button id='reload-todos-button' class='btn btn-info py-2'>Reload Todos</button>
</div>";

            // Act
            var component = RenderComponent<Todos>();

            // Assert
            component.MarkupMatches(expectedHtml);
        }

        [Fact(DisplayName = "Verify the error markup renders correctly when the state contains errors")]
        public void GivenInitialPageLoad_WhenErrorsExistInState_DispatchesLoadTodosWhenReloadClicked()
        {
            // Arrange
            var state = new TodosState(false, "Oh no!", null, null);
            _mockState.Setup(m => m.Value).Returns(state);

            // Act
            var component = RenderComponent<Todos>();
            component.Find("#reload-todos-button").Click();

            // Assert, LoadTodos will be called on initialization with no todos in state and once more when we click the button
            _mockFacade.Verify(m => m.LoadTodos(), Times.Exactly(2));
        }

        [Fact(DisplayName = "Verify the no todos found reload button dispatches the load todos action")]
        public void GivenInitialPageLoad_WhenNoTodosExistInState_DispatchesLoadTodosActionWhenReloadClicked()
        {
            // Arrange
            var state = new TodosState(false, null, Array.Empty<TodoDto>(), null);
            _mockState.Setup(m => m.Value).Returns(state);

            // Act
            var component = RenderComponent<Todos>();
            component.Find("#reload-todos-button").Click();

            // Assert
            _mockFacade.Verify(m => m.LoadTodos(), Times.Once);
        }

        [Fact(DisplayName = "Verify the todos table is rendered when todos exist in state")]
        public void GivenInitialPageLoad_WhenTodosExistInState_RenderesTodoTable()
        {
            // Arrange
            var state = new TodosState(false, null, new[] { new TodoDto { Id = 1, Completed = false, Title = "test", UserId = 1 } }, null);
            var todo = state.CurrentTodos.First();
            _mockState.Setup(m => m.Value).Returns(state);

            // Act
            var component = RenderComponent<Todos>();

            // Assert, verify one row was rendered
            var tableRow = component.FindAll("tbody > tr");
            tableRow.Count.ShouldBe(1);

            // Assert, verify the information in the columns is correct
            component.FindAll("td").Count.ShouldBe(4);
            int.Parse(component.Find($"#todo-id-{todo.Id}").InnerHtml).ShouldBe(todo.Id);
            component.Find($"#todo-id-{todo.Id}-title").InnerHtml.ShouldBe(todo.Title);
            bool.Parse(component.Find($"#todo-id-{todo.Id}-completed").InnerHtml).ShouldBe(todo.Completed);
            int.Parse(component.Find($"#todo-id-{todo.Id}-user-id").InnerHtml).ShouldBe(todo.UserId);
        }
    }
}
