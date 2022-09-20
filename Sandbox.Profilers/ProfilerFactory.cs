namespace Sandbox.Profilers;

public class ProfilerFactory : IProfilerFactory {
    private readonly ILoggerFactory _loggerFactory;
    private readonly IClock _clock;
    private readonly ConcurrentDictionary<string, IProfiler> _handlers;

    public ProfilerFactory(ILoggerFactory loggerFactory, IClock clock) {
        _handlers = new();
        _loggerFactory = loggerFactory;
        _clock = clock;
    }

    public IProfiler CreateSimpleProfiler(string category) =>
        _handlers.GetOrAdd(category, _ => new SimpleProfiler(category, _loggerFactory, _clock));
}