namespace StateManagementWithFluxor.Store.Features.Todos.Actions.DeleteTodo
{
    public class DeleteTodoAction
    {
        public DeleteTodoAction(int id) => 
            Id = id;

        public int Id { get; }
    }
}
