namespace Sandbox.Profilers;

public interface IReporter {
    IEnumerable<DetailedReportLine> GetDetailedReport();
    IEnumerable<SummaryReportLine> GetSummaryReport();
}