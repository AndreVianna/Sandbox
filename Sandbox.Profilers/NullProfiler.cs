namespace Sandbox.Profilers;

public class NullProfiler : IProfiler
{
    public Task MeasureAsync(Func<Task> executeAsync, [CallerMemberName] string action = "") => executeAsync();

    public Task<T> MeasureAsync<T>(Func<Task<T>> getAsync, [CallerMemberName] string action = "") => getAsync();

    public void Measure(Action execute, [CallerMemberName] string action = "") => execute();

    public T Measure<T>(Func<T> get, [CallerMemberName] string action = "") => get();
}
