using Fluxor;
using StateManagementWithFluxor.Store.Features.Todos.Actions.LoadTodoDetail;
using StateManagementWithFluxor.Store.State;

namespace StateManagementWithFluxor.Store.Features.Todos.Reducers
{
    public static class LoadTodoDetailActionsReducer
    {
        [ReducerMethod]
        public static TodosState ReduceLoadTodoDetailAction(TodosState state, LoadTodoDetailAction _) =>
            new TodosState(true, null, state.CurrentTodos, null);

        [ReducerMethod]
        public static TodosState ReduceLoadTodoDetailSuccessAction(TodosState state, LoadTodoDetailSuccessAction action) =>
            new TodosState(false, null, state.CurrentTodos, action.Todo);

        [ReducerMethod]
        public static TodosState ReduceLoadTodoDetailFailureAction(TodosState state, LoadTodoDetailFailureAction action) =>
            new TodosState(false, action.ErrorMessage, state.CurrentTodos, null);
    }
}
