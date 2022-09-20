namespace Sandbox.Profilers;

public interface IProfilingFactory {
    IProfiler CreateSimpleProfiler(string category);
    IReporter CreateSimpleReporter();
}