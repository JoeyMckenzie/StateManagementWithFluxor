using StateManagementWithFluxor.Models.Todos.Dtos;

namespace StateManagementWithFluxor.Store.Features.Todos.Actions.CreateTodo
{
    public class CreateTodoAction
    {
        public CreateTodoAction(CreateTodoDto todo) =>
            Todo = todo;

        public CreateTodoDto Todo { get; }
    }
}
