namespace Sandbox.Profilers;

public interface IProfilingFactory {
    IProfiler CreateProfiler(string category);
    IProfiler CreateProfiler<T>();
    IReporter CreateReporter();
}