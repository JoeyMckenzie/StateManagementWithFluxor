using StateManagementWithFluxor.Models.Todos;
using System.Collections.Generic;

namespace StateManagementWithFluxor.Store.Features.Todos.Actions
{
    public class LoadTodosSuccessAction
    {
        public LoadTodosSuccessAction(IEnumerable<TodoDto> todos) => 
            Todos = todos;

        public IEnumerable<TodoDto> Todos { get; }
    }
}
