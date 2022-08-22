namespace Mediator.BadAssembly;

public record BadTestRequest(string Name) : IRequest<BadTestResponse> {
}