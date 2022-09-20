namespace Sandbox.Profilers;

public class SimpleProfilerTests {
    private readonly LoggerSpy<SimpleProfiler> _loggerSpy;
    private readonly SimpleProfiler _profiler;

    public SimpleProfilerTests() {
        var clock = new FixedClock(2022, 1, 1);
        _loggerSpy = new();
        var loggerFactory = Substitute.For<ILoggerFactory>();
        loggerFactory.CreateLogger(Arg.Any<string>()).Returns(_loggerSpy);
        _profiler = new("SomeCategory", loggerFactory, clock);
    }

    [Fact]
    public void SimpleProfiler_Execute_ExecuteAction() {
        var isExecuted = false;

        _profiler.Execute("SomeAction", () => isExecuted = true);

        isExecuted.Should().BeTrue();
        _loggerSpy.Logs.Should().HaveCount(1);
        _loggerSpy.Logs[0].Should().Be("Executed action: 'SomeAction'. Start time: [2022-01-01 05:00:00.0000000]. Elapsed time: [0:00:00:00.0000000].");
    }

    [Fact]
    public void SimpleProfiler_Get_ReturnsResult() {
        var result = _profiler.Get("SomeAction", () => 42);

        result.Should().Be(42);
        _loggerSpy.Logs.Should().HaveCount(1);
        _loggerSpy.Logs[0].Should().Be("Executed action: 'SomeAction'. Start time: [2022-01-01 05:00:00.0000000]. Elapsed time: [0:00:00:00.0000000].");
    }

    [Fact]
    public async Task SimpleProfiler_ExecuteAsync_ExecuteAction() {
        var isExecuted = false;

        await _profiler.ExecuteAsync("SomeAction", () => Task.Run(() => isExecuted = true));

        isExecuted.Should().BeTrue();
        _loggerSpy.Logs.Should().HaveCount(1);
        _loggerSpy.Logs[0].Should().Be("Executed action: 'SomeAction'. Start time: [2022-01-01 05:00:00.0000000]. Elapsed time: [0:00:00:00.0000000].");
    }

    [Fact]
    public async Task SimpleProfiler_GetAsync_ReturnsResult() {
        var result = await _profiler.GetAsync("SomeAction", () => Task.FromResult(42));

        result.Should().Be(42);
        _loggerSpy.Logs.Should().HaveCount(1);
        _loggerSpy.Logs[0].Should().Be("Executed action: 'SomeAction'. Start time: [2022-01-01 05:00:00.0000000]. Elapsed time: [0:00:00:00.0000000].");
    }

    [Fact]
    public void SimpleProfiler_GetDetailedReport_ReturnsResult() {
        const int seed = 7649675;
        var random = new Random(seed);
        var loggerFactory = Substitute.For<ILoggerFactory>();
        var profiler = new SimpleProfiler("SomeCategory", loggerFactory, new SystemClock());
        for (var i = 0; i < 10; i++) {
            profiler.Execute("SomeAction", () => Thread.Sleep(random.Next(30, 50)));
        }

        var report = profiler.GetDetailedReport().ToArray();

        report.Should().HaveCount(10);
        report[0].Category.Should().Be("SomeCategory");
        report[0].Action.Should().Be("SomeAction");
        report[0].Start.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(10));
        report[0].ElapsedTime.Should().BeCloseTo(TimeSpan.FromMilliseconds(30), TimeSpan.FromMilliseconds(30));
    }

    [Fact]
    public void SimpleProfiler_GetSummaryReport_ReturnsResult() {
        const int seed = 7649675;
        var random = new Random(seed);
        var loggerFactory = Substitute.For<ILoggerFactory>();
        var profiler = new SimpleProfiler("SomeCategory", loggerFactory, new SystemClock());
        for (var i = 0; i < 100; i++) {
            profiler.Execute("SomeAction", () => Thread.Sleep(random.Next(30, 50)));
        }

        var summary = profiler.GetSummaryReport().ToArray();

        summary.Should().HaveCount(1);
        summary[0].Category.Should().Be("SomeCategory");
        summary[0].Action.Should().Be("SomeAction");
        summary[0].AverageElapsedTime.Should().BeCloseTo(TimeSpan.FromMilliseconds(40), TimeSpan.FromMilliseconds(10));
        summary[0].MinimumElapsedTime.Should().BeCloseTo(TimeSpan.FromMilliseconds(30), TimeSpan.FromMilliseconds(10));
        summary[0].MaximumElapsedTime.Should().BeCloseTo(TimeSpan.FromMilliseconds(60), TimeSpan.FromMilliseconds(10));
        summary[0].Count.Should().Be(100);
        summary[0].ElapsedTimeStandardError.Should().BeCloseTo(TimeSpan.FromTicks(600), TimeSpan.FromTicks(300));
    }
}