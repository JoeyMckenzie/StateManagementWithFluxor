using Fluxor;
using Microsoft.Extensions.Logging;
using StateManagementWithFluxor.Models.Todos.Dtos;
using StateManagementWithFluxor.Services;
using StateManagementWithFluxor.Store.Features.Todos.Actions.UpdateTodo;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace StateManagementWithFluxor.Store.Features.Todos.Effects.UpdateTodoEffect
{
    public class UpdateTodoEffect : Effect<UpdateTodoAction>
    {
        private readonly ILogger<UpdateTodoEffect> _logger;
        private readonly JsonPlaceholderApiService _apiService;

        public UpdateTodoEffect(ILogger<UpdateTodoEffect> logger, JsonPlaceholderApiService httpClient) =>
            (_logger, _apiService) = (logger, httpClient);

        protected override async Task HandleAsync(UpdateTodoAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation($"Updating todo {action.Id}...");
                var updateResponse = await _apiService.PutAsync($"todos/{action.Id}", action.Todo);

                if (!updateResponse.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error updating todo: {updateResponse.ReasonPhrase}");
                }

                _logger.LogInformation("Todo updated successfully!");
                var updatedTodo = await updateResponse.Content.ReadFromJsonAsync<TodoDto>();
                dispatcher.Dispatch(new UpdateTodoSuccessAction(updatedTodo));
            }
            catch (Exception e)
            {
                _logger.LogError($"Could not update todo, reason: {e.Message}");
                dispatcher.Dispatch(new UpdateTodoFailureAction(e.Message));
            }
        }
    }
}
