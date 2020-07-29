namespace StateManagementWithFluxor.Models.Todos.Dtos
{
    public class CreateOrUpdateTodoDto
    {
        public CreateOrUpdateTodoDto(string title, bool completed, int userId) =>
            (Title, Completed, UserId) = (title, completed, userId);

        public string Title { get; }

        public bool Completed { get; }

        public int UserId { get; }
    }
}
