#nullable disable

namespace System.Results;

using Validation;

public record FailedValidationResult : FailedResult {
    public FailedValidationResult(IEnumerable<ValidationError> errors) {
        Errors = errors?.ToArray() ?? throw new ArgumentNullException(nameof(errors));
        if (Errors.Count == 0) throw new ArgumentException("Error collection cannot be empty.", nameof(errors));
        if (Errors.Any(e => e is null)) throw new ArgumentException("Error collection cannot contain a null element.", nameof(errors));
    }

    public FailedValidationResult(ValidationError error)
        : this(new[] { error ?? throw new ArgumentNullException(nameof(error)) }) {
    }

    public IReadOnlyList<ValidationError> Errors { get; }
}

public record FailedValidationResult<TValue> : FailedResult<TValue> {
    public FailedValidationResult(IEnumerable<ValidationError> errors) {
        Errors = errors?.ToArray() ?? throw new ArgumentNullException(nameof(errors));
        if (Errors.Count == 0) throw new ArgumentException("Error collection cannot be empty.", nameof(errors));
        if (Errors.Any(e => e is null)) throw new ArgumentException("Error collection cannot contain a null element.", nameof(errors));
    }

    public FailedValidationResult(ValidationError error)
        : this(new[] { error ?? throw new ArgumentNullException(nameof(error)) }) {
    }

    public IReadOnlyList<ValidationError> Errors { get; }
}