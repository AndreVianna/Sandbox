namespace Mediator.BadAssembly;

public class DuplicatedHandler : IHandler<BadTestRequest, BadTestResponse> {
    public Task<BadTestResponse> HandleAsync(BadTestRequest request, CancellationToken cancellationToken = default) {
        return Task.FromResult(new BadTestResponse($"Duplicated {request.Name}!"));
    }
}