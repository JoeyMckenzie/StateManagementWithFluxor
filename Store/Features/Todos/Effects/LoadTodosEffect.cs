using Fluxor;
using Microsoft.Extensions.Logging;
using StateManagementWithFluxor.Models.Todos.Dtos;
using StateManagementWithFluxor.Services;
using StateManagementWithFluxor.Store.Features.Todos.Actions.LoadTodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagementWithFluxor.Store.Features.Todos.Effects
{
    public class LoadTodosEffect : Effect<LoadTodosAction>
    {
        private readonly ILogger<LoadTodosEffect> _logger;
        private readonly JsonPlaceholderApiService _apiService;

        public LoadTodosEffect(ILogger<LoadTodosEffect> logger, JsonPlaceholderApiService httpClient) =>
            (_logger, _apiService) = (logger, httpClient);

        protected override async Task HandleAsync(LoadTodosAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Loading todos...");
                var todosResponse = await _apiService.GetAsync<IEnumerable<TodoDto>>("todos");

                _logger.LogInformation("Todos loaded successfully!");
                dispatcher.Dispatch(new LoadTodosSuccessAction(todosResponse.Take(5)));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error loading todos, reason: {e.Message}");
                dispatcher.Dispatch(new LoadTodosFailureAction(e.Message));
            }

        }
    }
}
