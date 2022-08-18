namespace System.Results;

public record NotFoundResult() : FailureResult(Array.Empty<Error>());

public record NotFoundResult<T> : NotFoundResult, IResult<T> {
    public T Value => default!;
}
