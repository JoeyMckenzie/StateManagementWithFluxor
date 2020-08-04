using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using StateManagementWithFluxor.Store.Features.Todos.Actions.UpdateTodo;
using System.Threading.Tasks;

namespace StateManagementWithFluxor.Store.Features.Todos.Effects.UpdateTodoEffect
{
    public class UpdateTodoSuccessEffect : Effect<UpdateTodoSuccessAction>
    {
        private readonly ILogger<UpdateTodoSuccessEffect> _logger;
        private readonly NavigationManager _navigation;

        public UpdateTodoSuccessEffect(ILogger<UpdateTodoSuccessEffect> logger, NavigationManager navigation) =>
            (_logger, _navigation) = (logger, navigation);

        protected override Task HandleAsync(UpdateTodoSuccessAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation("Updated todo successfully, navigating back to todo listing...");
            _navigation.NavigateTo("todos");

            return Task.CompletedTask;
        }
    }
}
