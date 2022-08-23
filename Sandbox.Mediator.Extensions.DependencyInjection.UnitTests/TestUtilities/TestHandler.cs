namespace Mediator.TestUtilities;

public class TestHandler : IHandler<TestRequest, TestResponse> {
    public Task<TestResponse> HandleAsync(TestRequest request, CancellationToken cancellationToken = default) {
        return Task.FromResult(new TestResponse($"Hello {request.Name}!"));
    }
}