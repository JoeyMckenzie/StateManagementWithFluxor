using StateManagementWithFluxor.Models.Todos.Dtos;
using System.Collections.Generic;

namespace StateManagementWithFluxor.Store.Features.Todos.Actions.LoadTodos
{
    public class LoadTodosSuccessAction
    {
        public LoadTodosSuccessAction(IEnumerable<TodoDto> todos) =>
            Todos = todos;

        public IEnumerable<TodoDto> Todos { get; }
    }
}
