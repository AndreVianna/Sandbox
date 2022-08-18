namespace System.Results;

public record InternalErrorResult : FailureResult {
    public InternalErrorResult(Exception exception, IEnumerable<Error> errors) : base(errors) {
        Exception = exception ?? throw new ArgumentNullException(nameof(exception));
    }

    public InternalErrorResult(Exception exception, Error error) : base(error) {
        Exception = exception ?? throw new ArgumentNullException(nameof(exception));
    }

    public InternalErrorResult(Exception exception) {
        Exception = exception ?? throw new ArgumentNullException(nameof(exception));
    }

    public Exception Exception { get; }
}

public record InternalErrorResult<TValue> : InternalErrorResult, IResult<TValue> {
    public InternalErrorResult(Exception exception, IEnumerable<Error> errors) : base(exception, errors) { }
    public InternalErrorResult(Exception exception, Error error) : base(exception, error) { }
    public InternalErrorResult(Exception exception) : base(exception) { }

    public TValue Value => default!;
}
