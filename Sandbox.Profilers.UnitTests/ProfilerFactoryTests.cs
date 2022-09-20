namespace Sandbox.Profilers;

public class ProfilerFactoryTests {
    [Fact]
    public void ProfilerFactory_CreateSimpleProfiler_ReturnsSimpleProfiler() {
        var clock = Substitute.For<IClock>();
        var loggerFactory = Substitute.For<ILoggerFactory>();
        var factory = new ProfilerFactory(loggerFactory, clock);

        var subject = factory.CreateSimpleProfiler("SomeCategory");

        subject.Should().BeOfType<SimpleProfiler>();
    }
}