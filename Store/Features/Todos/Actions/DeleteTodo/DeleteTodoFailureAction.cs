using StateManagementWithFluxor.Store.Features.Shared.Actions;

namespace StateManagementWithFluxor.Store.Features.Todos.Actions.DeleteTodo
{
    public class DeleteTodoFailureAction : FailureAction
    {
        public DeleteTodoFailureAction(string errorMessage) 
            : base(errorMessage)
        {
        }
    }
}
