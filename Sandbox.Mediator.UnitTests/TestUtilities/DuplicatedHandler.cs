namespace Mediator.TestUtilities;

internal class DuplicatedHandler : IHandler<TestRequest, TestResponse> {
    public Task<TestResponse> HandleAsync(TestRequest request, CancellationToken cancellationToken = default) {
        return Task.FromResult(new TestResponse($"Duplicated {request.Name}!"));
    }
}