using Fluxor;
using StateManagementWithFluxor.Store.Features.Todos.Actions.LoadTodos;
using StateManagementWithFluxor.Store.State;

namespace StateManagementWithFluxor.Store.Features.Todos.Reducers
{
    public static class LoadTodosActionsReducer
    {
        [ReducerMethod]
        public static TodosState ReduceLoadTodosAction(TodosState state, LoadTodosAction _) =>
            new TodosState(true, null, null, state.CurrentTodo);

        [ReducerMethod]
        public static TodosState ReduceLoadTodosSuccessAction(TodosState state, LoadTodosSuccessAction action) =>
            new TodosState(false, null, action.Todos, state.CurrentTodo);

        [ReducerMethod]
        public static TodosState ReduceLoadTodosFailureAction(TodosState state, LoadTodosFailureAction action) =>
            new TodosState(false, action.ErrorMessage, null, state.CurrentTodo);
    }
}
