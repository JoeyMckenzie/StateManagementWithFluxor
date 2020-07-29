using Fluxor;
using Microsoft.Extensions.Logging;
using StateManagementWithFluxor.Models.Todos.Dtos;
using StateManagementWithFluxor.Store.Features.Todos.Actions.CreateTodo;
using StateManagementWithFluxor.Store.Features.Todos.Actions.DeleteTodo;
using StateManagementWithFluxor.Store.Features.Todos.Actions.LoadTodoDetail;
using StateManagementWithFluxor.Store.Features.Todos.Actions.LoadTodos;
using StateManagementWithFluxor.Store.Features.Todos.Actions.UpdateTodo;

namespace StateManagementWithFluxor.Services
{
    public class StateFacade
    {
        private readonly ILogger<StateFacade> _logger;
        private readonly IDispatcher _dispatcher;

        public StateFacade(ILogger<StateFacade> logger, IDispatcher dispatcher) =>
            (_logger, _dispatcher) = (logger, dispatcher);

        public void LoadTodos()
        {
            _logger.LogInformation("Issuing action to load todos...");
            _dispatcher.Dispatch(new LoadTodosAction());
        }

        public void LoadTodoById(int id)
        {
            _logger.LogInformation($"Issuing action to load todo {id}...");
            _dispatcher.Dispatch(new LoadTodoDetailAction(id));
        }

        public void CreateTodo(string title, bool completed, int userId)
        {
            // Construct our validated todo
            var todoDto = new CreateOrUpdateTodoDto(title, completed, userId);

            _logger.LogInformation($"Issuing action to create todo [{title}] for user [{userId}]");
            _dispatcher.Dispatch(new CreateTodoAction(todoDto));
        }

        public void UpdateTodo(int id, string title, bool completed, int userId)
        {
            // Construct our validated todo
            var todoDto = new CreateOrUpdateTodoDto(title, completed, userId);

            _logger.LogInformation($"Issuing action to update todo {id}");
            _dispatcher.Dispatch(new UpdateTodoAction(id, todoDto));
        }

        public void DeleteTodo(int id)
        {
            _logger.LogInformation($"Issuing action to delete todo {id}");
            _dispatcher.Dispatch(new DeleteTodoAction(id));
        }
    }
}
