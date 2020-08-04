using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using StateManagementWithFluxor.Store.Features.Todos.Actions.DeleteTodo;
using System.Threading.Tasks;

namespace StateManagementWithFluxor.Store.Features.Todos.Effects
{
    public class DeleteTodoSuccessEffect : Effect<DeleteTodoSuccessAction>
    {
        private readonly ILogger<DeleteTodoSuccessEffect> _logger;
        private readonly NavigationManager _navigation;

        public DeleteTodoSuccessEffect(ILogger<DeleteTodoSuccessEffect> logger, NavigationManager navigation) =>
            (_logger, _navigation) = (logger, navigation);

        protected override Task HandleAsync(DeleteTodoSuccessAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation("Deleted todo successfully, navigating back to todo listing...");
            _navigation.NavigateTo("todos");

            return Task.CompletedTask;
        }
    }
}
