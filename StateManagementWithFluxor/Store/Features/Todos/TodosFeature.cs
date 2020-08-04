using Fluxor;
using StateManagementWithFluxor.Store.State;

namespace StateManagementWithFluxor.Store.Features.Todos
{
    public class TodosFeature : Feature<TodosState>
    {
        public override string GetName() => "Todos";

        protected override TodosState GetInitialState() =>
            new TodosState(true, null, null, null);
    }
}
