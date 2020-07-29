using StateManagementWithFluxor.Store.Features.Shared.Actions;

namespace StateManagementWithFluxor.Store.Features.Todos.Actions.UpdateTodo
{
    public class UpdateTodoFailureAction : FailureAction
    {
        public UpdateTodoFailureAction(string errorMessage) 
            : base(errorMessage)
        {
        }
    }
}
