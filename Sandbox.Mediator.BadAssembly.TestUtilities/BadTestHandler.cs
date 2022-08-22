namespace Mediator.BadAssembly;

public class BadTestHandler : IHandler<BadTestRequest, BadTestResponse> {
    public Task<BadTestResponse> HandleAsync(BadTestRequest request, CancellationToken cancellationToken = default) {
        return Task.FromResult(new BadTestResponse($"Hello {request.Name}!"));
    }
}
