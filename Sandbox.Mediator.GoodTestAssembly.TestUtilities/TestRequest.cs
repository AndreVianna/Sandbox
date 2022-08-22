namespace Mediator.GoodAssembly;

public record TestRequest(string Name) : IRequest<TestResponse> {
}