namespace Sandbox.Profilers;

public class ProfilingFactoryTests {
    [Fact]
    public void ProfilingFactory_CreateSimpleProfiler_ReturnsSimpleProfiler() {
        var clock = Substitute.For<IClock>();
        var loggerFactory = Substitute.For<ILoggerFactory>();
        var factory = new ProfilingFactory(loggerFactory, clock);

        var subject = factory.CreateProfiler("SomeCategory");

        subject.Should().BeOfType<SimpleProfiler>();
    }

    [Fact]
    public void ProfilingFactory_CreateSimpleProfiler_WithTypeParameter_ReturnsSimpleProfiler() {
        var clock = Substitute.For<IClock>();
        var loggerFactory = Substitute.For<ILoggerFactory>();
        var factory = new ProfilingFactory(loggerFactory, clock);

        var subject = factory.CreateProfiler<ProfilingFactoryTests>();

        subject.Should().BeOfType<SimpleProfiler>();
    }

    [Fact]
    public void ProfilingFactory_CreateSimpleReporter_ReturnsSimpleReporter() {
        var clock = Substitute.For<IClock>();
        var loggerFactory = Substitute.For<ILoggerFactory>();
        var factory = new ProfilingFactory(loggerFactory, clock);

        var subject = factory.CreateReporter();

        subject.Should().BeOfType<SimpleReporter>();
    }
}