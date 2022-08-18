namespace System.Collections;

public interface IOffsetPagedCollection<out T> : IPagedCollection<T> {
    uint TotalCount { get; }
    uint PageIndex { get; }
}