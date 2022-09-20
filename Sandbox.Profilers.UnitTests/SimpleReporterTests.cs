namespace Sandbox.Profilers;

public class SimpleReporterTests {
    [Fact]
    public void SimpleReporter_GetDetailedReport_ReturnsReport() {
        var clock = new SlidingClock(new DateTime(2022, 1, 1).ToUniversalTime(), TimeSpan.FromMilliseconds(40));
        var loggerFactory = Substitute.For<ILoggerFactory>();
        loggerFactory.CreateLogger(Arg.Any<string>()).Returns(Substitute.For<ILogger>());
        var factory = new ProfilingFactory(loggerFactory, clock);

        var profiler = factory.CreateSimpleProfiler("SomeCategory");
        for (var i = 0; i < 100; i++) {
            profiler.Execute("SomeAction", () => { });
        }

        var reporter = factory.CreateSimpleReporter();

        var report = reporter.GetDetailedReport().ToArray();

        report.Should().HaveCount(100);
        report[0].Category.Should().Be("SomeCategory");
        report[0].Action.Should().Be("SomeAction");
        report[0].Start.Should().Be(new DateTime(2022, 1, 1).ToUniversalTime());
        report[0].ElapsedTime.Should().Be(TimeSpan.FromMilliseconds(40));
    }

    [Fact]
    public void SimpleProfiler_GetSummaryReport_ReturnsReport() {
        var seed = 57983745;
        var random = new Random(seed);
        var clock = new VaryingClock(new DateTime(2022, 1, 1).ToUniversalTime(), () => TimeSpan.FromMilliseconds(40 + random.Next(0, 21)));
        var loggerFactory = Substitute.For<ILoggerFactory>();
        loggerFactory.CreateLogger(Arg.Any<string>()).Returns(Substitute.For<ILogger>());
        var factory = new ProfilingFactory(loggerFactory, clock);

        var profiler = factory.CreateSimpleProfiler("SomeCategory");
        for (var i = 0; i < 100; i++) {
            profiler.Execute("SomeAction", () => { });
        }

        var reporter = factory.CreateSimpleReporter();

        var summary = reporter.GetSummaryReport().ToArray();

        summary.Should().HaveCount(1);
        summary[0].Category.Should().Be("SomeCategory");
        summary[0].Action.Should().Be("SomeAction");
        summary[0].AverageElapsedTime.Should().BeCloseTo(TimeSpan.FromMilliseconds(50), TimeSpan.FromMilliseconds(5));
        summary[0].MinimumElapsedTime.Should().Be(TimeSpan.FromMilliseconds(40));
        summary[0].MaximumElapsedTime.Should().Be(TimeSpan.FromMilliseconds(60));
        summary[0].Count.Should().Be(100);
        summary[0].ElapsedTimeStandardError.Should().Be(TimeSpan.FromTicks(00611));
    }
}