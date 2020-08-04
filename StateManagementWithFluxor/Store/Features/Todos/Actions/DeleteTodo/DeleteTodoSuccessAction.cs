namespace StateManagementWithFluxor.Store.Features.Todos.Actions.DeleteTodo
{
    public class DeleteTodoSuccessAction
    {
        public DeleteTodoSuccessAction(int id) => 
            Id = id;

        public int Id { get; }
    }
}
