namespace StateManagementWithFluxor.Store.Features.Todos.Actions
{
    public class LoadTodosFailureAction
    {
        public LoadTodosFailureAction(string errorMessage) => 
            ErrorMessage = errorMessage;

        public string ErrorMessage { get; }
    }
}
