using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using StateManagementWithFluxor.Models.Todos;
using StateManagementWithFluxor.Store.Features.Todos.Actions.LoadTodoDetail;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace StateManagementWithFluxor.Store.Features.Todos.Effects
{
    public class LoadTodoDetailEffect : Effect<LoadTodoDetailAction>
    {
        private readonly ILogger<LoadTodoDetailEffect> _logger;
        private readonly HttpClient _httpClient;

        public LoadTodoDetailEffect(ILogger<LoadTodoDetailEffect> logger, HttpClient httpClient) =>
            (_logger, _httpClient) = (logger, httpClient);

        protected override async Task HandleAsync(LoadTodoDetailAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation($"Loading todo {action.Id}...");

                // Add a little extra latency for dramatic effect...
                await Task.Delay(TimeSpan.FromMilliseconds(1000));
                var todoResponse = await _httpClient.GetFromJsonAsync<TodoDto>($"todos/{action.Id}");

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
