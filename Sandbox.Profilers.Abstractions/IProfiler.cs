using System.Runtime.CompilerServices;

namespace Sandbox.Profilers;

public interface IProfiler {
    Task MeasureAsync(Func<Task> executeAsync, [CallerMemberName] string action = "");
    Task<T> MeasureAsync<T>(Func<Task<T>> getAsync, [CallerMemberName] string action = "");
    void Measure(Action execute, [CallerMemberName] string action = "");
    T Measure<T>(Func<T> get, [CallerMemberName] string action = "");
}
