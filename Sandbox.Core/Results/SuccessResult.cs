namespace System.Results;

public record SuccessResult : IResult {
    public IReadOnlyCollection<Error> Errors => Array.Empty<Error>();
}

public record SuccessResult<T>(T Value) : SuccessResult, IResult<T>;
