using StateManagementWithFluxor.Store.Features.Shared.Actions;

namespace StateManagementWithFluxor.Store.Features.Todos.Actions.LoadTodos
{
    public class LoadTodosFailureAction : FailureAction
    {
        public LoadTodosFailureAction(string errorMessage) 
            : base(errorMessage)
        {
        }
    }
}
