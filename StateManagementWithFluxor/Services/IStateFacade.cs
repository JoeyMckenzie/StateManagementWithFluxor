namespace StateManagementWithFluxor.Services
{
    public interface IStateFacade
    {
        void LoadTodos();

        void LoadTodoById(int id);

        void CreateTodo(string title, bool completed, int userId);

        void UpdateTodo(int id, string title, bool completed, int userId);

        void DeleteTodo(int id);
    }
}
