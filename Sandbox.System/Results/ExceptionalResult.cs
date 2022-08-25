namespace System.Results;

public record ExceptionalResult : FailedResult {
    // ReSharper disable once ConvertToPrimaryConstructor
    public ExceptionalResult(Exception exception) {
        Exception = exception ?? throw new ArgumentNullException(nameof(exception));
    }

    public Exception Exception { get; }

    public void Throw() => throw Exception;
}

public record ExceptionalResult<TValue> : FailedResult<TValue> {
    // ReSharper disable once ConvertToPrimaryConstructor
    public ExceptionalResult(Exception exception) {
        Exception = exception ?? throw new ArgumentNullException(nameof(exception));
    }

    public Exception Exception { get; }

    public void Throw() => throw Exception;
}