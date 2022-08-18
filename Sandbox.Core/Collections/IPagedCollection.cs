namespace System.Collections;

public interface IPagedCollection<out T> {
    uint PageSize { get; }
    IReadOnlyCollection<T> Items { get; }
}