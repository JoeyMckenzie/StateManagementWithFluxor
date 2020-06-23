using StateManagementWithFluxor.Models.Todos;
using System.Collections.Generic;

namespace StateManagementWithFluxor.Store.State
{
    public class TodosState
    {
        public TodosState(bool isLoading, IEnumerable<TodoDto>? currentTodos) =>
            (IsLoading, CurrentTodos) = (isLoading, currentTodos);

        public bool IsLoading { get; }

        public IEnumerable<TodoDto>? CurrentTodos { get; }
    }
}
