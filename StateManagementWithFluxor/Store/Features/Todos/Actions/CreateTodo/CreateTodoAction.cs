using StateManagementWithFluxor.Models.Todos.Dtos;

namespace StateManagementWithFluxor.Store.Features.Todos.Actions.CreateTodo
{
    public class CreateTodoAction
    {
        public CreateTodoAction(CreateOrUpdateTodoDto todo) =>
            Todo = todo;

        public CreateOrUpdateTodoDto Todo { get; }
    }
}
