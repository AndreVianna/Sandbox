namespace Sandbox.Profilers;

public class ProfilingFactory : IProfilingFactory {
    private readonly ILoggerFactory _loggerFactory;
    private readonly IClock _clock;
    private readonly ConcurrentDictionary<string, IProfiler> _handlers;

    public ProfilingFactory(ILoggerFactory loggerFactory, IClock clock) {
        _handlers = new();
        _loggerFactory = loggerFactory;
        _clock = clock;
    }

    public IProfiler CreateProfiler(string category) =>
        _handlers.GetOrAdd(category, _ => new SimpleProfiler(category, _loggerFactory, _clock));

    public IProfiler CreateProfiler<T>() => CreateProfiler(typeof(T).Name);

    public IReporter CreateReporter() =>
        new SimpleReporter(_handlers);
}