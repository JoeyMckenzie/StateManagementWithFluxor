using Fluxor;
using Fluxor.Blazor.Web.Middlewares.Routing;
using StateManagementWithFluxor.Store.State;

namespace StateManagementWithFluxor.Store.Features.Shared.Reducers
{
    public static class NavigationActionsReducer
    {
        [ReducerMethod]
        public static TodosState ReduceNavigationAction(TodosState state, GoAction _) =>
            new TodosState(state.IsLoading, null, state.CurrentTodos, state.CurrentTodo);
    }
}
