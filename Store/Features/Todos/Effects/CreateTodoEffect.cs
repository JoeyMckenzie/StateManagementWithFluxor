using Fluxor;
using Microsoft.Extensions.Logging;
using StateManagementWithFluxor.Models.Todos.Dtos;
using StateManagementWithFluxor.Services;
using StateManagementWithFluxor.Store.Features.Todos.Actions.CreateTodo;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace StateManagementWithFluxor.Store.Features.Todos.Effects.CreateTodo
{
    public class CreateTodoEffect : Effect<CreateTodoAction>
    {
        private readonly ILogger<CreateTodoEffect> _logger;
        private readonly JsonPlaceholderApiService _apiService;

        public CreateTodoEffect(ILogger<CreateTodoEffect> logger, JsonPlaceholderApiService httpClient) =>
            (_logger, _apiService) = (logger, httpClient);

        protected override async Task HandleAsync(CreateTodoAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation($"Creating todo {action.Todo}...");
                var createResponse = await _apiService.PostAsync("todos", action.Todo);

                if (!createResponse.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error creating todo: {createResponse.ReasonPhrase}");
                }

                _logger.LogInformation("Todo created successfully!");
                var createdTodo = await createResponse.Content.ReadFromJsonAsync<TodoDto>();
                dispatcher.Dispatch(new CreateTodoSuccessAction(createdTodo));
            }
            catch (Exception e)
            {
                _logger.LogError($"Could not create todo, reason: {e.Message}");
                dispatcher.Dispatch(new CreateTodoFailureAction(e.Message));
            }
        }
    }
}
