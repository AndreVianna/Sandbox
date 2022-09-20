namespace Sandbox.Profilers;

public class SimpleReporter : IReporter {
    private readonly ConcurrentDictionary<string, IProfiler> _handlers;

    public SimpleReporter(ConcurrentDictionary<string, IProfiler> handlers) {
        _handlers = handlers;
    }

    public IEnumerable<DetailedReportLine> GetDetailedReport() =>
        _handlers.Keys
            .Select(category => new {
                category,
                records = ((SimpleProfiler)_handlers[category]).Records
            })
            .SelectMany(x => GetProfilerReport(x.category, x.records))
            .OrderBy(i => i.Start)
            .ToArray();

    public IEnumerable<SummaryReportLine> GetSummaryReport() =>
        _handlers.Keys
            .Select(category => new {
                category,
                records = ((SimpleProfiler)_handlers[category]).Records
            })
            .SelectMany(x => GetProfilerReportSummary(x.category, x.records))
            .ToArray();

    private static IEnumerable<DetailedReportLine> GetProfilerReport(string category, ConcurrentDictionary<string, ConcurrentBag<ProfilingRecord>> records) =>
        records.SelectMany(x => x.Value.Select(y => new DetailedReportLine(category, x.Key, y)));


    private static IEnumerable<SummaryReportLine> GetProfilerReportSummary(string category, ConcurrentDictionary<string, ConcurrentBag<ProfilingRecord>> records) =>
        records.Select(x => new SummaryReportLine(category, x.Key, x.Value));
}