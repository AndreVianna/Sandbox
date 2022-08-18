namespace System.Collections;

public record Pagination {
    public const uint MaxSize = 1_000;
    public const uint MinSize = 1;

    public static uint DefaultPageSize { get; private set; } = 20;

    public static void Configure(uint pageSize) {
        DefaultPageSize = pageSize > MaxSize ? MaxSize : pageSize < 1 ? DefaultPageSize : pageSize;
    }

    protected Pagination(uint size = 0) {
        Size = Math.Min(MaxSize, size < MinSize ? DefaultPageSize : size);
    }

    public uint Size { get; } = DefaultPageSize;
}