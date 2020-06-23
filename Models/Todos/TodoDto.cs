namespace StateManagementWithFluxor.Models.Todos
{
    public class TodoDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Body { get; set; }

        public int UserId { get; set; }
    }
}
