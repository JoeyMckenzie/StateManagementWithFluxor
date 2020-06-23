using StateManagementWithFluxor.Models.Todos;
using System.Collections.Generic;

namespace StateManagementWithFluxor.Store.State
{
    public class TodosState : RootState
    {
        public TodosState(bool isLoading, string? currentErrorMessage, IEnumerable<TodoDto>? currentTodos) 
            : base(isLoading, currentErrorMessage)
        {
            CurrentTodos = currentTodos;
        }

        public IEnumerable<TodoDto>? CurrentTodos { get; }
    }
}
