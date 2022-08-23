using Mediator.TestUtilities;

namespace Mediator;

public class MediatorTests {

    [Fact]
    public async Task Mediator_SendAsync_SendsRequest() {
        var provider = Substitute.For<IServiceProvider>();
        var handlerType = typeof(IHandler<TestRequest, TestResponse>);
        provider.GetService(handlerType).Returns(new TestHandler());
        var subject = new Mediator(provider);
        var request = new TestRequest("world");

        var response = await subject.SendAsync(request);

        var result = response.Should().BeOfType<TestResponse>().Subject;
        result.Greeting.Should().Be("Hello world!");
    }

    [Fact]
    public async Task Mediator_SendAsync_WithServiceNotFound_Throws() {
        var provider = Substitute.For<IServiceProvider>();
        var handlerType = typeof(IHandler<TestRequest, TestResponse>);
        provider.GetService(handlerType).Returns(null);
        var subject = new Mediator(provider);
        var request = new TestRequest("world");

        var  action = () => subject.SendAsync(request);

        await action.Should().ThrowAsync<InvalidOperationException>().WithMessage("No handler found for TestRequest.");
    }

    [Fact]
    public async Task Mediator_SendAsync_ForAction_SendsRequest() {
        var provider = Substitute.For<IServiceProvider>();
        var handlerType = typeof(IHandler<ActionRequest>);
        provider.GetService(handlerType).Returns(new ActionHandler());
        var subject = new Mediator(provider);
        var request = new ActionRequest("data");

        await subject.SendAsync(request);
    }

    [Fact]
    public async Task Mediator_SendAsync_ForAction_WithServiceNotFound_Throws() {
        var provider = Substitute.For<IServiceProvider>();
        var handlerType = typeof(IHandler<ActionRequest>);
        provider.GetService(handlerType).Returns(null);
        var subject = new Mediator(provider);
        var request = new ActionRequest("data");

        var action = () => subject.SendAsync(request);

        await action.Should().ThrowAsync<InvalidOperationException>().WithMessage("No handler found for ActionRequest.");
    }
}