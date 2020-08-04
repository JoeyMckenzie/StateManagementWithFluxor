namespace StateManagementWithFluxor.Store.Features.Todos.Actions.LoadTodoDetail
{
    public class LoadTodoDetailAction
    {
        public LoadTodoDetailAction(int id) => 
            Id = id;

        public int Id { get; set; }
    }
}
