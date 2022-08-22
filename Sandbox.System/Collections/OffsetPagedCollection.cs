namespace System.Collections;

public static class OffsetPagedCollection {
    public static IOffsetPagedCollection<TItem> Empty<TItem>() => new OffsetPagedCollection<TItem>();
}

public record OffsetPagedCollection<T> : IOffsetPagedCollection<T> {
    public uint PageSize { get; init; } = Pagination.DefaultPageSize;
    public uint PageIndex { get; init; }
    public uint TotalCount { get; init; }
    public IReadOnlyCollection<T> Items { get; init; } = Array.Empty<T>();
}