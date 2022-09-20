using Sandbox.Profilers.Abstractions;

namespace Sandbox.Profilers;

public interface IProfilerFactory {
    IProfiler CreateSimpleProfiler(string category);
}