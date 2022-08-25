namespace System.Results;

public abstract record FailedResult : IResult;

public abstract record FailedResult<TValue> : IResult<TValue> {
    public TValue Value => default!;
}