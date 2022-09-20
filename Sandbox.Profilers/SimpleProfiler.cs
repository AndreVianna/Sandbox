namespace Sandbox.Profilers;

public class SimpleProfiler : IProfiler {
    private const string _logMessageTemplate = "Executed action: '{Category}.{Action}'. Start time: [{Start:yyyy-MM-dd HH:mm:ss.fffffff}]. Elapsed time: [{ElapsedTime:G}].";

    private readonly ILogger _logger;
    private readonly string _category;
    private readonly IClock _clock;

    internal ConcurrentDictionary<string, ConcurrentBag<ProfilingRecord>> Records { get; }

    public SimpleProfiler(string category, ILoggerFactory loggerFactory, IClock clock) {
        _logger = loggerFactory.CreateLogger(category);
        _category = category;
        _clock = clock;

        Records = new();
    }

    public void Measure(Action execute, [CallerMemberName] string action = "") {
        var start = _clock.UtcNow;
        execute();
        RecordAction(action, start, _clock.UtcNow - start);
    }

    public async Task MeasureAsync(Func<Task> executeAsync, [CallerMemberName] string action = "") {
        var start = _clock.UtcNow;
        await executeAsync();
        RecordAction(action, start, _clock.UtcNow - start);
    }

    public T Measure<T>(Func<T> get, [CallerMemberName] string action = "") {
        var start = _clock.UtcNow;
        var result = get();
        RecordAction(action, start, _clock.UtcNow - start);

        return result;
    }

    public async Task<T> MeasureAsync<T>(Func<Task<T>> getAsync, [CallerMemberName] string action = "") {
        var start = _clock.UtcNow;
        var result = await getAsync();
        RecordAction(action, start, _clock.UtcNow - start);

        return result;
    }

    private void RecordAction(string name, DateTime start, TimeSpan elapsedTime) {
        _logger.LogTrace(_logMessageTemplate, _category, name, start, elapsedTime);
        var bag = Records.GetOrAdd(name, _ => new());
        bag.Add(new(start, elapsedTime.Ticks));
    }
}