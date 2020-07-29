using System.ComponentModel.DataAnnotations;

namespace StateManagementWithFluxor.Models.Todos.Validation
{
    public class CreateOrUpdateTodoValidationModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Your todo must have a title")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Status of this todo is required")]
        public bool Completed { get; set; }

        [Required(ErrorMessage = "User ID associated with this todo is required")]
        [Range(1, 100)]
        public int UserId { get; set; }
    }
}
