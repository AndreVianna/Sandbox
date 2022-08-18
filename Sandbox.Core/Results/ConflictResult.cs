namespace System.Results;

public record ConflictResult() : FailureResult;

public record ConflictResult<TValue> : ConflictResult, IResult<TValue> {
    public TValue Value => default!;
}
