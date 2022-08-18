namespace System.Results;

public abstract record FailureResult : IResult {
    protected FailureResult(IEnumerable<Error> errors) {
        Errors = errors?.ToArray() ?? throw new ArgumentNullException(nameof(errors));
    }

    protected FailureResult(Error error)
        : this(new[] { error ?? throw new ArgumentNullException(nameof(error)) }) {
    }

    protected FailureResult() : this(Array.Empty<Error>()) {
    }

    public IReadOnlyCollection<Error> Errors { get; }
}
