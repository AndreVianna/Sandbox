#nullable disable

namespace System.Results;

public record ValidationErrorResult : FailureResult {
    public ValidationErrorResult(IEnumerable<Error> errors) {
        Errors = errors?.ToArray() ?? throw new ArgumentNullException(nameof(errors));
        if (Errors.Count == 0) throw new ArgumentException("Collection cannot be empty.", nameof(errors));
        if (Errors.Any(e => e is null)) throw new ArgumentException("Collection cannot contain a null element.", nameof(errors));
    }

    public ValidationErrorResult(Error error)
        : this(new[] { error ?? throw new ArgumentNullException(nameof(error)) }) {
    }

    public IReadOnlyCollection<Error> Errors { get; }
}

public record ValidationErrorResult<TValue> : ValidationErrorResult, IResult<TValue> {
    public ValidationErrorResult(Error error) : base(error) { }
    public ValidationErrorResult(IEnumerable<Error> errors) : base(errors) { }

    public TValue Value => default!;
}
