using Fluxor;
using Microsoft.Extensions.Logging;
using StateManagementWithFluxor.Store.Features.Todos.Actions;

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
            _logger.LogInformation("Issuing action to load todods...");
            _dispatcher.Dispatch(new LoadTodosAction());
        }
    }
}
