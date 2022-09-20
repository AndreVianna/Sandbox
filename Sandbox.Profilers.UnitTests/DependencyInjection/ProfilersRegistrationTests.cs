namespace Sandbox.Profilers.DependencyInjection;

public class ProfilersRegistrationTests
{
    [Fact]
public void ProfilersRegistration_AddSimpleProfilerServices_AddsServices() {
    var loggerSpy = new LoggerSpy<SimpleProfiler>();
    var fakeLoggerFactory = Substitute.For<ILoggerFactory>();
    fakeLoggerFactory.CreateLogger(Arg.Any<string>()).Returns(loggerSpy);

    var services = new ServiceCollection();
    services.AddSingleton(fakeLoggerFactory);

    var result = services.AddProfilers();

    result.Should().BeSameAs(services);
    var provider = services.BuildServiceProvider();
    var factory = provider.GetRequiredService<IProfilingFactory>();
    factory.Should().BeOfType<ProfilingFactory>();
    var clock = provider.GetRequiredService<IClock>();
    clock.Should().BeOfType<SystemClock>();
}
}