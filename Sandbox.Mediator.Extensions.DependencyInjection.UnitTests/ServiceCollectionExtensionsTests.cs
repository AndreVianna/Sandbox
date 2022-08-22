namespace Mediator;

using GoodAssembly;
using BadAssembly;

public class ServiceCollectionExtensionsTests {
    private static readonly ServiceDescriptor _mediatorDescriptor = new(typeof(IMediator), typeof(Mediator), ServiceLifetime.Singleton);
    private static readonly ServiceDescriptor _handlerDescriptor = new(typeof(IHandler<TestRequest, TestResponse>), typeof(TestHandler), ServiceLifetime.Scoped);
    private static readonly ServiceDescriptor _actionDescriptor = new(typeof(IHandler<ActionRequest>), typeof(ActionHandler), ServiceLifetime.Scoped);
    private readonly ServiceCollection _services;

    public ServiceCollectionExtensionsTests() {
        _services = new();
    }

    [Fact]
    public void ServiceCollectionExtensions_AddMediator_AddsServices() {
        var result = _services.AddMediator(typeof(GoodAssemblyMarker));

        result.Should().BeSameAs(_services);
        _services.Count.Should().Be(3);
        _services[0].Should().BeEquivalentTo(_actionDescriptor);
        _services[1].Should().BeEquivalentTo(_handlerDescriptor);
        _services[2].Should().BeEquivalentTo(_mediatorDescriptor);
    }

    [Fact]
    public void ServiceCollectionExtensions_AddMediator_WithDuplicatedService_Throws() {
        var action = () => _services.AddMediator(typeof(BadAssemblyMarker));

        action.Should().Throw<InvalidOperationException>().WithMessage("Duplicate handler found for IHandler<BadTestRequest,BadTestResponse>.");
    }

    [Fact]
    public void ServiceCollectionExtensions_AddMediatorFromT_AddsServices() {
        var result = _services.AddMediatorFrom<GoodAssemblyMarker>();

        result.Should().BeSameAs(_services);
        _services.Count.Should().Be(3);
        _services[0].Should().BeEquivalentTo(_actionDescriptor);
        _services[1].Should().BeEquivalentTo(_handlerDescriptor);
        _services[2].Should().BeEquivalentTo(_mediatorDescriptor);
    }
}