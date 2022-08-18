namespace System.Results;

public record InternalErrorResult(Exception Exception) : FailureResult {
    public Exception Exception { get; } = Exception ?? throw new ArgumentNullException(nameof(Exception));
}

public record InternalErrorResult<TValue>(Exception Exception) : InternalErrorResult(Exception), IResult<TValue> {
    public TValue Value => default!;
}
