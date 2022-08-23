namespace Mediator;

public sealed class Mediator : IMediator {
    private readonly IServiceProvider _provider;

    public Mediator(IServiceProvider provider) {
        _provider = provider;
    }

    public Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default) {
        var serviceType = typeof(IHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var service = _provider.GetService(serviceType);
        if (service is null)
            throw new InvalidOperationException($"No handler found for {request.GetType().Name}.");
        var handleMethod = service.GetType().GetMethod("HandleAsync")!;
        return (Task<TResponse>)handleMethod.Invoke(service, new object[] { request, cancellationToken })!;
    }

    public Task SendAsync(IRequest request, CancellationToken cancellationToken = default) {
        var serviceType = typeof(IHandler<>).MakeGenericType(request.GetType());
        var service = _provider.GetService(serviceType);
        if (service is null)
            throw new InvalidOperationException($"No handler found for {request.GetType().Name}.");
        var handleMethod = service.GetType().GetMethod("HandleAsync")!;
        return (Task)handleMethod.Invoke(service, new object[] { request, cancellationToken })!;
    }
}
