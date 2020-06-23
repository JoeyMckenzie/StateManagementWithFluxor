using StateManagementWithFluxor.Models.Todos;

namespace StateManagementWithFluxor.Store.Features.Todos.Actions.LoadTodoDetail
{
    public class LoadTodoDetailSuccess
    {
        public LoadTodoDetailSuccess(TodoDto todo) => 
            Todo = todo;

        public TodoDto Todo { get; }
    }
}
