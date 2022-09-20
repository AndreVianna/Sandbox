namespace Sandbox.Profilers;

public class SimpleProfilerTests {
    private readonly LoggerSpy _loggerSpy;
    private readonly SimpleProfiler _profiler;


    public SimpleProfilerTests() {
        var clock = new SlidingClock(new DateTime(2022, 1, 1).ToUniversalTime(), TimeSpan.FromMilliseconds(50));
        _loggerSpy = new();
        var loggerFactory = Substitute.For<ILoggerFactory>();
        loggerFactory.CreateLogger(Arg.Any<string>()).Returns(_loggerSpy);
        _profiler = new("SimpleProfilerTests", loggerFactory, clock);
    }

    [Fact]
    public void SimpleProfiler_Measure_ForAction_ExecuteAction() {
        const string expectedMessage =
            "Executed action: 'SimpleProfilerTests.SimpleProfiler_Measure_ForAction_ExecuteAction'. Start time: [2022-01-01 05:00:00.0000000]. Elapsed time: [0:00:00:00.0500000].";

        var isExecuted = false;

        _profiler.Measure(() => {
            // Do something.
            isExecuted = true;
        });

        isExecuted.Should().BeTrue();
        _loggerSpy.Logs.Should().HaveCount(1);
        _loggerSpy.Logs[0].Should().Be(expectedMessage);
    }

    [Fact]
    public void SimpleProfiler_Measure_ForFunc_ReturnsResult() {
        const string expectedMessage =
            "Executed action: 'SimpleProfilerTests.SimpleProfiler_Measure_ForFunc_ReturnsResult'. Start time: [2022-01-01 05:00:00.0000000]. Elapsed time: [0:00:00:00.0500000].";

        var result = _profiler.Measure(() => 42);

        result.Should().Be(42);
        _loggerSpy.Logs.Should().HaveCount(1);
        _loggerSpy.Logs[0].Should().Be(expectedMessage);
    }

    [Fact]
    public async Task SimpleProfiler_MeasureAsync_ForTask_ExecuteAction() {
        const string expectedMessage =
            "Executed action: 'SimpleProfilerTests.SimpleProfiler_MeasureAsync_ForTask_ExecuteAction'. Start time: [2022-01-01 05:00:00.0000000]. Elapsed time: [0:00:00:00.0500000].";

        var isExecuted = false;

        await _profiler.MeasureAsync(() => {
            // Do something.
            isExecuted = true;
            return Task.CompletedTask;
        });

        isExecuted.Should().BeTrue();
        _loggerSpy.Logs.Should().HaveCount(1);
        _loggerSpy.Logs[0].Should().Be(expectedMessage);
    }

    [Fact]
    public async Task SimpleProfiler_MeasureAsync_ForTaskOfT_ReturnsResult() {
        const string expectedMessage =
            "Executed action: 'SimpleProfilerTests.SimpleProfiler_MeasureAsync_ForTaskOfT_ReturnsResult'. Start time: [2022-01-01 05:00:00.0000000]. Elapsed time: [0:00:00:00.0500000].";

        var result = await _profiler.MeasureAsync(() => Task.FromResult(42));

        result.Should().Be(42);
        _loggerSpy.Logs.Should().HaveCount(1);
        _loggerSpy.Logs[0].Should().Be(expectedMessage);
    }
}