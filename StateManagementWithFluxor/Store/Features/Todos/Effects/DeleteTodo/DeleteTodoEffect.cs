using Fluxor;
using Microsoft.Extensions.Logging;
using StateManagementWithFluxor.Services;
using StateManagementWithFluxor.Store.Features.Todos.Actions.DeleteTodo;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StateManagementWithFluxor.Store.Features.Todos.Effects.DeleteTodo
{
    public class DeleteTodoEffect : Effect<DeleteTodoAction>
    {
        private readonly ILogger<DeleteTodoEffect> _logger;
        private readonly JsonPlaceholderApiService _apiService;

        public DeleteTodoEffect(ILogger<DeleteTodoEffect> logger, JsonPlaceholderApiService apiService) =>
            (_logger, _apiService) = (logger, apiService);

        protected override async Task HandleAsync(DeleteTodoAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation($"Deleting todo {action.Id}...");
                var deleteResponse = await _apiService.DeleteAsync($"todos/{action.Id}");

                if (!deleteResponse.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error deleting todo: {deleteResponse.ReasonPhrase}");
                }

                _logger.LogInformation($"Todo deleted successfully!");
                dispatcher.Dispatch(new DeleteTodoSuccessAction(action.Id));
            }
            catch (Exception e)
            {
                _logger.LogError($"Could not create todo, reason: {e.Message}");
                dispatcher.Dispatch(new DeleteTodoFailureAction(e.Message));
            }
        }
    }
}
