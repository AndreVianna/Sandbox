﻿namespace Sandbox.Profilers;

public record ProfilingDetailedReportLine {
    public ProfilingDetailedReportLine(string category, string action, ProfilingRecord record) {
        Category = category;
        Action = action;
        Start = record.Start;
        ElapsedTime = TimeSpan.FromTicks(record.ElapsedTicks);
    }

    public string Category { get; }
    public string Action { get; }
    public DateTime Start { get; }
    public TimeSpan ElapsedTime { get; }
}