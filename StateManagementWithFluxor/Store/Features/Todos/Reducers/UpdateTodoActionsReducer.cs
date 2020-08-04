using Fluxor;
using StateManagementWithFluxor.Models.Todos.Dtos;
using StateManagementWithFluxor.Store.Features.Todos.Actions.UpdateTodo;
using StateManagementWithFluxor.Store.State;
using System.Collections.Generic;
using System.Linq;

namespace StateManagementWithFluxor.Store.Features.Todos.Reducers
{
    public static class UpdateTodoActionsReducer
    {
        [ReducerMethod]
        public static TodosState ReduceUpdateTodoAction(TodosState state, UpdateTodoAction _) =>
            new TodosState(true, null, state.CurrentTodos, state.CurrentTodo);

        [ReducerMethod]
        public static TodosState ReduceUpdateTodoSuccessAction(TodosState state, UpdateTodoSuccessAction action)
        {
            // If the current todos list is null, set the state with a new list containing the updated todo
            if (state.CurrentTodos is null)
            {
                return new TodosState(false, null, new List<TodoDto> { action.Todo }, state.CurrentTodo);
            }

            // Rather than mutating in place, let's construct a new list and add our updated item
            var updatedList = state.CurrentTodos
                .Where(t => t.Id != action.Todo.Id)
                .ToList();

            // Add the todo and sort the list
            updatedList.Add(action.Todo);
            updatedList = updatedList
                .OrderBy(t => t.Id)
                .ToList();

            return new TodosState(false, null, updatedList, null);
        }

        [ReducerMethod]
        public static TodosState ReduceUpdateTodoFailureAction(TodosState state, UpdateTodoFailureAction action) =>
            new TodosState(false, action.ErrorMessage, state.CurrentTodos, state.CurrentTodo);
    }
}
