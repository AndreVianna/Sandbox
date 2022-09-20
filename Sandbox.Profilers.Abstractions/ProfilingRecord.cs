namespace Sandbox.Profilers;

public record ProfilingRecord {
    public ProfilingRecord(DateTime start, long elapsedTicks) {
        Start = start;
        ElapsedTicks = elapsedTicks;
    }

    public DateTime Start { get; }
    public long ElapsedTicks { get; }
}