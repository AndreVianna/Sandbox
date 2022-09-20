namespace Sandbox.Profilers;

public class ProfilingFactoryTests {
    [Fact]
    public void ProfilingFactory_CreateSimpleProfiler_ReturnsSimpleProfiler() {
        var clock = Substitute.For<IClock>();
        var loggerFactory = Substitute.For<ILoggerFactory>();
        var factory = new ProfilingFactory(loggerFactory, clock);

        var subject = factory.CreateSimpleProfiler("SomeCategory");

        subject.Should().BeOfType<SimpleProfiler>();
    }

    [Fact]
    public void ProfilingFactory_CreateSimpleReporter_ReturnsSimpleReporter() {
        var clock = Substitute.For<IClock>();
        var loggerFactory = Substitute.For<ILoggerFactory>();
        var factory = new ProfilingFactory(loggerFactory, clock);

        var subject = factory.CreateSimpleReporter();

        subject.Should().BeOfType<SimpleReporter>();
    }
}