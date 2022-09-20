namespace Sandbox.Profilers;

public class SimpleProfilerTests {
    private readonly LoggerSpy<SimpleProfiler> _loggerSpy;
    private readonly SimpleProfiler _profiler;

    private const string _expectedMessage = 
        "Executed action: 'SomeCategory.SomeAction'. Start time: [2022-01-01 05:00:00.0000000]. Elapsed time: [0:00:00:00.0500000].";

    public SimpleProfilerTests() {
        var clock = new SlidingClock(new DateTime(2022, 1, 1).ToUniversalTime(), TimeSpan.FromMilliseconds(50));
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
        _loggerSpy.Logs[0].Should().Be(_expectedMessage);
    }

    [Fact]
    public void SimpleProfiler_Get_ReturnsResult() {
        var result = _profiler.Get("SomeAction", () => 42);

        result.Should().Be(42);
        _loggerSpy.Logs.Should().HaveCount(1);
        _loggerSpy.Logs[0].Should().Be(_expectedMessage);
    }

    [Fact]
    public async Task SimpleProfiler_ExecuteAsync_ExecuteAction() {
        var isExecuted = false;

        await _profiler.ExecuteAsync("SomeAction", () => Task.Run(() => isExecuted = true));

        isExecuted.Should().BeTrue();
        _loggerSpy.Logs.Should().HaveCount(1);
        _loggerSpy.Logs[0].Should().Be(_expectedMessage);
    }

    [Fact]
    public async Task SimpleProfiler_GetAsync_ReturnsResult() {
        var result = await _profiler.GetAsync("SomeAction", () => Task.FromResult(42));

        result.Should().Be(42);
        _loggerSpy.Logs.Should().HaveCount(1);
        _loggerSpy.Logs[0].Should().Be(_expectedMessage);
    }
}