using Fluxor;
using StateManagementWithFluxor.Store.Features.Todos.Actions;
using StateManagementWithFluxor.Store.State;

namespace StateManagementWithFluxor.Store.Features.Todos.Reducers
{
    public static class TodoActionsReducer
    {
        [ReducerMethod]
        public static TodosState ReduceLoadTodosAction(TodosState _, LoadTodosAction __) =>
            new TodosState(true, null, null);

        [ReducerMethod]
        public static TodosState ReduceLoadTodosSuccessAction(TodosState _, LoadTodosSuccessAction action) =>
            new TodosState(false, null, action.Todos);

        [ReducerMethod]
        public static TodosState ReduceLoadTodosFailureAction(TodosState _, LoadTodosFailureAction action) =>
            new TodosState(false, action.ErrorMessage, null);
    }
}
