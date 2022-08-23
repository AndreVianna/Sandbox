namespace Mediator.TestUtilities;

public class ActionHandler : IHandler<ActionRequest> {
    public Task HandleAsync(ActionRequest request, CancellationToken cancellationToken = default) {
        return Task.CompletedTask;
    }
}