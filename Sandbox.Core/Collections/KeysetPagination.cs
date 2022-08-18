namespace System.Collections;

using static PaginationDirection;

public record KeysetPagination : Pagination {
    public static KeysetPagination Default() => new();

    public KeysetPagination(object key = default!, PaginationDirection direction = Forward, uint size = 0) : base(size) {
        Direction = direction;
        Key = key;
    }

    public PaginationDirection Direction { get; }
    public object Key { get; }
}
