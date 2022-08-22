namespace System.Collections;

public static class KeysetPagedCollection {
    public static IKeysetPagedCollection<T> Empty<T>() => new KeysetPagedCollection<T>();
}

public record KeysetPagedCollection<T> : IKeysetPagedCollection<T> {
    public uint PageSize { get; init; } = Pagination.DefaultPageSize;
    public IReadOnlyCollection<T> Items { get; init; } = Array.Empty<T>();
}
