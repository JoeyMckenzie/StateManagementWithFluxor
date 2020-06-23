using StateManagementWithFluxor.Models.Todos;
using System.Collections.Generic;

namespace StateManagementWithFluxor.Store.State
{
    public class TodosState
    {
        public TodosState(bool isLoading, string? currentErrorMessage, IEnumerable<TodoDto>? currentTodos) =>
            (IsLoading, CurrentErrorMessage, CurrentTodos) = (isLoading, currentErrorMessage, currentTodos);

        public bool IsLoading { get; }

        public string? CurrentErrorMessage { get; }

        public bool HasCurrentErrors => !string.IsNullOrWhiteSpace(CurrentErrorMessage);

        public IEnumerable<TodoDto>? CurrentTodos { get; }
    }
}
