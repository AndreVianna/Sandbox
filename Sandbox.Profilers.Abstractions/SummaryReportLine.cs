using System.Collections.Concurrent;

namespace Sandbox.Profilers;

public record SummaryReportLine {
    public SummaryReportLine(string category, string action, ConcurrentBag<ProfilingRecord> records) {
        Category = category;
        Action = action;
        Count = records.Count;
        var average = records.Average(x => x.ElapsedTicks);
        AverageElapsedTime = TimeSpan.FromTicks(Convert.ToInt64(average));
        MinimumElapsedTime = TimeSpan.FromTicks(records.Min(x => x.ElapsedTicks));
        MaximumElapsedTime = TimeSpan.FromTicks(records.Max(x => x.ElapsedTicks));
        var stdErr = Math.Sqrt(records.Sum(x => Math.Pow(x.ElapsedTicks - average, 2)) / (Count - 1)) / Count;
        ElapsedTimeStandardError = TimeSpan.FromTicks(Convert.ToInt64(stdErr));
    }

    public string Category { get; }
    public string Action { get; }
    public int Count { get; }
    public TimeSpan AverageElapsedTime { get; }
    public TimeSpan MaximumElapsedTime { get; }
    public TimeSpan MinimumElapsedTime { get; }
    public TimeSpan ElapsedTimeStandardError { get; }
}