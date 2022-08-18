#nullable disable

namespace System.Results;

public abstract record FailureResult : IResult {
}

public abstract record FailureResultWithErrors : FailureResult, IResultWithErrors {
    protected FailureResultWithErrors(IEnumerable<Error> errors) {
        Errors = errors?.ToArray() ?? throw new ArgumentNullException(nameof(errors));
        if (Errors.Count == 0) throw new ArgumentException("Collection cannot be empty.", nameof(errors));
        if (Errors.Any(e => e is null)) throw new ArgumentException("Collection cannot contain a null element", nameof(errors));
    }

    protected FailureResultWithErrors(Error error)
        : this(new[] { error ?? throw new ArgumentNullException(nameof(error)) }) {
    }

    public IReadOnlyCollection<Error> Errors { get; }
}
