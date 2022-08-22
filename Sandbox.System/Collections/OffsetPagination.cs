namespace System.Collections;

public record OffsetPagination : Pagination {
    public const uint MaxCount = 1_000_000_000;
    public const uint MaxIndex = 999_999_999;

    public static OffsetPagination Default() => new();

    public OffsetPagination(uint index = 0, uint size = 0, uint totalCount = MaxCount) : base(size) {
        var count = Math.Min(MaxCount, totalCount);
        LastIndex = count == 0 ? 0 : ((Math.Min(MaxCount, count) / Size) - 1);
        Index = Math.Min(LastIndex, index);
    }

    public uint Index { get; }
    public uint LastIndex { get; }
}