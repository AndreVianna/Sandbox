using System.Linq.Expressions;

namespace System.Linq;

public static class QueryableExtensions {
    public static IQueryable<TResult> Project<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
        => source.Select(selector);

    public static IQueryable<TResult> Project<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, int, TResult>> selector)
        => source.Select(selector);

    public static IQueryable<TResult> Expand<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, IEnumerable<TResult>>> selector)
        => source.SelectMany(selector);

    public static IQueryable<TResult> Expand<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, int, IEnumerable<TResult>>> selector)
        => source.SelectMany(selector);

    public static IQueryable<TResult> Expand<TSource, TCollection, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, IEnumerable<TCollection>>> collectionSelector, Expression<Func<TSource, TCollection, TResult>> resultSelector)
        => source.SelectMany(collectionSelector, resultSelector);

    public static IQueryable<TResult> Expand<TSource, TCollection, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, int, IEnumerable<TCollection>>> collectionSelector, Expression<Func<TSource, TCollection, TResult>> resultSelector)
        => source.SelectMany(collectionSelector, resultSelector);
}