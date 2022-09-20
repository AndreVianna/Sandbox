namespace Sandbox.Profilers;

public class NullProfilerTests {
    private readonly NullProfiler _profiler;

    public NullProfilerTests() {
        _profiler = new();
    }

    [Fact]
    public void SimpleProfiler_Measure_ForAction_ExecuteAction() {
        var isExecuted = false;

        _profiler.Measure(() => {
            // Do something.
            isExecuted = true;
        });

        isExecuted.Should().BeTrue();
    }

    [Fact]
    public void SimpleProfiler_Measure_ForFunc_ReturnsResult() {
        var result = _profiler.Measure(() => 42);

        result.Should().Be(42);
    }

    [Fact]
    public async Task SimpleProfiler_MeasureAsync_ForTask_ExecuteAction() {
        var isExecuted = false;

        await _profiler.MeasureAsync(() => {
            // Do something.
            isExecuted = true;
            return Task.CompletedTask;
        });

        isExecuted.Should().BeTrue();
    }

    [Fact]
    public async Task SimpleProfiler_MeasureAsync_ForTaskOfT_ReturnsResult() {
        var result = await _profiler.MeasureAsync(() => Task.FromResult(42));

        result.Should().Be(42);
    }
}