namespace System.Results;

public record NotFoundResult : FailureResult;

public record NotFoundResult<T> : NotFoundResult, IResult<T> {
    public T Value => default!;
}
