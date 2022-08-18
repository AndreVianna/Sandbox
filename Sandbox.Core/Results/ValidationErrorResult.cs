namespace System.Results;

public record ValidationErrorResult : FailureResultWithErrors {
    public ValidationErrorResult(IEnumerable<Error> errors) : base(errors) { }
    public ValidationErrorResult(Error error) : base(error) { }
}

public record ValidationErrorResult<TValue> : ValidationErrorResult, IResult<TValue> {
    public ValidationErrorResult(Error error) : base(error) { }
    public ValidationErrorResult(IEnumerable<Error> errors) : base(errors) { }

    public TValue Value => default!;
}
