namespace System.Results;

public record ValidationErrorResult : FailureResult {
    public ValidationErrorResult(IEnumerable<Error> errors) : base(errors) {
        if (Errors.Count == 0) throw new ArgumentException("Collection cannot be empty.", nameof(errors));
    }
    public ValidationErrorResult(Error error) : base(error) { }
}

public record ValidationErrorResult<TValue> : ValidationErrorResult, IResult<TValue> {
    public ValidationErrorResult(Error error) : base(error) { }
    public ValidationErrorResult(IEnumerable<Error> errors) : base(errors) { }

    public TValue Value => default!;
}
