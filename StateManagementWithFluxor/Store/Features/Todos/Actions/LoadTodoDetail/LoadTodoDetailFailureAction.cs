using StateManagementWithFluxor.Store.Features.Shared.Actions;

namespace StateManagementWithFluxor.Store.Features.Todos.Actions.LoadTodoDetail
{
    public class LoadTodoDetailFailureAction : FailureAction
    {
        public LoadTodoDetailFailureAction(string errorMessage) 
            : base(errorMessage)
        {
        }
    }
}
