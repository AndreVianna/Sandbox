namespace Sandbox.Profilers.Abstractions;

public interface IProfiler {
    Task ExecuteAsync(string action, Func<Task> executeAsync, bool resumeOnSameThread = false);
    Task<T> GetAsync<T>(string action, Func<Task<T>> getAsync, bool resumeOnSameThread = false);
    void Execute(string action, Action execute);
    T Get<T>(string action, Func<T> get);

    IEnumerable<ProfilingDetailedReportLine> GetDetailedReport();
    IEnumerable<ProfilingReportSummaryLine> GetSummaryReport();
}
