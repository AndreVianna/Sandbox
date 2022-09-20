using Mediator.TestUtilities;

namespace Mediator.DependencyInjection;

public class MediatorRegistrationTests {
    private static readonly ServiceDescriptor _mediatorDescriptor = new(typeof(IMediator), typeof(Mediator), ServiceLifetime.Singleton);
    private static readonly ServiceDescriptor _handlerDescriptor = new(typeof(IHandler<TestRequest, TestResponse>), typeof(TestHandler), ServiceLifetime.Scoped);
    private static readonly ServiceDescriptor _actionDescriptor = new(typeof(IHandler<ActionRequest>), typeof(ActionHandler), ServiceLifetime.Scoped);
    private readonly ServiceCollection _services;

    public MediatorRegistrationTests() {
        _services = new();
    }

    [Fact]
    public void MediatorRegistration_AddMediator_AddsServices() {
        var result = _services.AddMediator(typeof(AssemblyMarker));

        result.Should().BeSameAs(_services);
        _services.Count.Should().Be(3);
        _services[0].Should().BeEquivalentTo(_actionDescriptor);
        _services[1].Should().BeEquivalentTo(_handlerDescriptor);
        _services[2].Should().BeEquivalentTo(_mediatorDescriptor);
    }

    [Fact]
    public void MediatorRegistration_AddMediatorFromT_AddsServices() {
        var result = _services.AddMediatorFrom<AssemblyMarker>();

        result.Should().BeSameAs(_services);
        _services.Count.Should().Be(3);
        _services[0].Should().BeEquivalentTo(_actionDescriptor);
        _services[1].Should().BeEquivalentTo(_handlerDescriptor);
        _services[2].Should().BeEquivalentTo(_mediatorDescriptor);
    }

    [Fact]
    public void MediatorRegistration_EnsureUniqueness_WithDuplicatedHandler_Throws() {
        var handlers = new List<(Type Service, Type Implementation)> {
            (typeof(IHandler<TestRequest, TestResponse>), typeof(TestHandler)),
            (typeof(IHandler<TestRequest, TestResponse>), typeof(DuplicatedHandler))
        };

        var action = () => MediatorRegistration.EnsureUniqueness(handlers);

        action.Should().Throw<InvalidOperationException>().WithMessage("Duplicate handler found for IHandler<TestRequest,TestResponse>. Found implementations: TestHandler, DuplicatedHandler.");
    }
}