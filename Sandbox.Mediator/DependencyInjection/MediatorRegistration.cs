namespace Mediator.DependencyInjection;

public static class MediatorRegistration {
    public static IServiceCollection AddMediatorFrom<T>(this IServiceCollection services) =>
        AddMediator(services, typeof(T));

    public static IServiceCollection AddMediator(this IServiceCollection services, Type markerType) {
        var assembly = markerType.Assembly;
        foreach (var type in FindHandlers(assembly))
            services.TryAddScoped(type.Service, type.Implementtion);

        services.TryAddSingleton<IMediator, Mediator>();

        return services;
    }

    private static IEnumerable<(Type Service, Type Implementtion)> FindHandlers(Assembly assembly) {
        var query = from t in assembly.ExportedTypes
            let interfaces = t.GetTypeInfo().ImplementedInterfaces.ToArray()
            where ImplementsIHandler(interfaces)
            select (Service: interfaces[0], Implementation: t);

        var handlers = query.ToArray();
        EnsureUniqueness(handlers);
        return handlers;
    }

    private static bool ImplementsIHandler(IReadOnlyList<Type> interfaces) =>
        interfaces.Count > 0
        && interfaces[0].IsGenericType
        && (interfaces[0].GetGenericTypeDefinition() == typeof(IHandler<,>)
            || interfaces[0].GetGenericTypeDefinition() == typeof(IHandler<>));

    internal static void EnsureUniqueness(IEnumerable<(Type Service, Type Implementation)> handlers) {
        var duplicatedHandlers = handlers.GroupBy(x => x.Service).FirstOrDefault(g => g.Count() > 1);
        if (duplicatedHandlers == null) return;
        var types = string.Join(",", duplicatedHandlers.Key.GenericTypeArguments.Select(t => t.Name));
        var implementations = string.Join(", ", duplicatedHandlers.Select(i => i.Implementation.Name));
        throw new InvalidOperationException($"Duplicate handler found for IHandler<{types}>. Found implementations: {implementations}.");
    }
}
