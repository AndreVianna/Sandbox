namespace Mediator;

public static class ServiceCollectionExtensions {
    public static IServiceCollection AddMediatorFrom<T>(this IServiceCollection services) {
        return AddMediator(services, typeof(T));
    }

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
                        where IsHandler(interfaces)
                        select (Service: interfaces[0], Implementation: t);

        var handlers = query.ToArray();
        var duplicatedHandler = handlers.GroupBy(x => x.Service).FirstOrDefault(g => g.Count() > 1);
        if (duplicatedHandler == null) return handlers;

        var types = string.Join(",", duplicatedHandler.Key.GenericTypeArguments.Select(t => t.Name));
        throw new InvalidOperationException($"Duplicate handler found for IHandler<{types}>.");

        static bool IsHandler(IReadOnlyList<Type> interfaces) =>
            interfaces.Count > 0
            && interfaces[0].IsGenericType
            && (interfaces[0].GetGenericTypeDefinition() == typeof(IHandler<,>)
                || interfaces[0].GetGenericTypeDefinition() == typeof(IHandler<>));
    }
}
