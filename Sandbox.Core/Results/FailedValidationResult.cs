#nullable disable

namespace System.Results;

public record FailedValidationResult : FailedResult {
    public FailedValidationResult(IEnumerable<Error> errors) {
        Errors = errors?.ToArray() ?? throw new ArgumentNullException(nameof(errors));
        if (Errors.Count == 0) throw new ArgumentException("Error collection cannot be empty.", nameof(errors));
        if (Errors.Any(e => e is null)) throw new ArgumentException("Error collection cannot contain a null element.", nameof(errors));
    }

    public FailedValidationResult(Error error)
        : this(new[] { error ?? throw new ArgumentNullException(nameof(error)) }) {
    }

    public IReadOnlyCollection<Error> Errors { get; }
}
