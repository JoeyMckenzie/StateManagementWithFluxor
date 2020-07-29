using Fluxor;
using StateManagementWithFluxor.Store.Features.Todos.Actions.DeleteTodo;
using StateManagementWithFluxor.Store.State;
using System.Linq;

namespace StateManagementWithFluxor.Store.Features.Todos.Reducers
{
    public static class DeleteTodoActionsReducer
    {
        [ReducerMethod]
        public static TodosState ReduceDeletTodoAction(TodosState state, DeleteTodoAction _) =>
            new TodosState(true, null, state.CurrentTodos, state.CurrentTodo);

        [ReducerMethod]
        public static TodosState ReduceDeleteTodoSuccessAction(TodosState state, DeleteTodoSuccessAction action)
        {
            // Return the default state if no list of todos is found
            if (state.CurrentTodos is null)
            {
                return new TodosState(false, null, null, state.CurrentTodo);
            }

            // Create a new list with all todo items excluding the todo with the deleted ID
            var updatedTodos = state.CurrentTodos.Where(t => t.Id != action.Id);

            return new TodosState(false, null, updatedTodos, state.CurrentTodo);
        }

        [ReducerMethod]
        public static TodosState ReduceDeleteTodoFailureAction(TodosState state, DeleteTodoFailureAction action) =>
            new TodosState(false, action.ErrorMessage, state.CurrentTodos, state.CurrentTodo);
    }
}
