namespace Sandbox.Profilers.DependencyInjection;

public static class ProfilersRegistration
{
    public static IServiceCollection AddProfilers(this IServiceCollection services) {
        services.TryAddSingleton<IClock, SystemClock>();
        services.TryAddSingleton<IProfilingFactory, ProfilingFactory>();
        return services;
    }
}