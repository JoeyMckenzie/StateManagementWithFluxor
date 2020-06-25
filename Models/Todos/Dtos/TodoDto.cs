namespace StateManagementWithFluxor.Models.Todos.Dtos
{
    public class TodoDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public bool Completed { get; set; }

        public int UserId { get; set; }
    }
}
