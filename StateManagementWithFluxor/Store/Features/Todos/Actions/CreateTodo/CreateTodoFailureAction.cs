using StateManagementWithFluxor.Store.Features.Shared.Actions;

namespace StateManagementWithFluxor.Store.Features.Todos.Actions.CreateTodo
{
    public class CreateTodoFailureAction : FailureAction
    {
        public CreateTodoFailureAction(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}
