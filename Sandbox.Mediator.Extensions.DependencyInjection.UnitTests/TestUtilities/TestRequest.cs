namespace Mediator.TestUtilities;

public record TestRequest(string Name) : IRequest<TestResponse> {
}