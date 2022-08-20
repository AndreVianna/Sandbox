namespace System.Linq;

public static class EnumerableExtensions {
    public static IEnumerable<TResult> Project<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) {
        return source.Select(selector);
    }

    public static IEnumerable<TResult> Project<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector) {
        return source.Select(selector);
    }

    public static IEnumerable<TResult> Expand<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector) {
        return source.SelectMany(selector);
    }

    public static IEnumerable<TResult> Expand<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector) {
        return source.SelectMany(selector);
    }

    public static IEnumerable<TResult> Expand<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
        return source.SelectMany(collectionSelector, resultSelector);
    }

    public static IEnumerable<TResult> Expand<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
        return source.SelectMany(collectionSelector, resultSelector);
    }
}