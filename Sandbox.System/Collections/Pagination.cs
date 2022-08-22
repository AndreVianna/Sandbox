namespace System.Collections;

public record Pagination {
    public const uint MaxSize = 1_000;
    public const uint MinSize = 1;

    public static uint DefaultPageSize { get; private set; } = 20;

    public static void Configure(uint pageSize) {
        if (pageSize < MinSize) return;
        DefaultPageSize = Math.Min(pageSize, MaxSize);
    }

    protected Pagination(uint size = 0) {
        Size = size < MinSize ? DefaultPageSize : Math.Min(size, MaxSize);
    }

    public uint Size { get; }
}