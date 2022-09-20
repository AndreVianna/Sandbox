using System;

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

    public void Execute(string action, Action execute) {
        var start = _clock.UtcNow;
        execute();
        RecordAction(action, start, _clock.UtcNow - start);
    }

    public async Task ExecuteAsync(string action, Func<Task> executeAsync, bool resumeOnSameThread = false) {
        var start = _clock.UtcNow;
        await executeAsync().ConfigureAwait(resumeOnSameThread);
        RecordAction(action, start, _clock.UtcNow - start);
    }

    public T Get<T>(string action, Func<T> get) {
        var start = _clock.UtcNow;
        var result = get();
        RecordAction(action, start, _clock.UtcNow - start);

        return result;
    }

    public async Task<T> GetAsync<T>(string action, Func<Task<T>> getAsync, bool resumeOnSameThread = false) {
        var start = _clock.UtcNow;
        var result = await getAsync().ConfigureAwait(resumeOnSameThread);
        RecordAction(action, start, _clock.UtcNow - start);

        return result;
    }

    private void RecordAction(string name, DateTime start, TimeSpan elapsedTime) {
        _logger.LogTrace(_logMessageTemplate, _category, name, start, elapsedTime);
        var bag = Records.GetOrAdd(name, _ => new());
        bag.Add(new(start, elapsedTime.Ticks));
    }
}