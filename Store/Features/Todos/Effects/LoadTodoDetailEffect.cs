using Fluxor;
using Microsoft.Extensions.Logging;
using StateManagementWithFluxor.Models.Todos.Dtos;
using StateManagementWithFluxor.Services;
using StateManagementWithFluxor.Store.Features.Todos.Actions.LoadTodoDetail;
using System;
using System.Threading.Tasks;

namespace StateManagementWithFluxor.Store.Features.Todos.Effects
{
    public class LoadTodoDetailEffect : Effect<LoadTodoDetailAction>
    {
        private readonly ILogger<LoadTodoDetailEffect> _logger;
        private readonly JsonPlaceholderApiService _apiService;

        public LoadTodoDetailEffect(ILogger<LoadTodoDetailEffect> logger, JsonPlaceholderApiService httpClient) =>
            (_logger, _apiService) = (logger, httpClient);

        protected override async Task HandleAsync(LoadTodoDetailAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation($"Loading todo {action.Id}...");
                var todoResponse = await _apiService.GetAsync<TodoDto>($"todos/{action.Id}");

                _logger.LogInformation($"Todo {action.Id} loaded successfully!");
                dispatcher.Dispatch(new LoadTodoDetailSuccessAction(todoResponse));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error loading todo {action.Id}, reason: {e.Message}");
                dispatcher.Dispatch(new LoadTodoDetailFailureAction(e.Message));
            }

        }
    }
}
