using StateManagementWithFluxor.Models.Todos.Dtos;

namespace StateManagementWithFluxor.Store.Features.Todos.Actions.UpdateTodo
{
    public class UpdateTodoAction
    {
        public UpdateTodoAction(int id, CreateOrUpdateTodoDto todo) => 
            (Id, Todo) = (id, todo);

        public int Id { get; }

        public CreateOrUpdateTodoDto Todo { get; }
    }
}
