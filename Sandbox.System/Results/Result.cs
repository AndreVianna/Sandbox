namespace System.Results;

using Validation;

public static class Result {
    public static IResult Success() {
        return new SuccessfulResult();
    }

    public static IResult<T> Success<T>(T value) {
        return new SuccessfulResultFor<T>(value);
    }

    public static IResult Exception(Exception exception) {
        return new ExceptionalResult(exception);
    }

    public static IResult<T> Exception<T>(Exception exception) {
        return new ExceptionalResult<T>(exception);
    }

    public static IResult Conflict(string? reason = null) {
        return new ConflictingResult(reason);
    }

    public static IResult<T> Conflict<T>(string? reason = null) {
        return new ConflictingResult<T>(reason);
    }

    public static IResult NotFound() {
        return new NotFoundResult();
    }

    public static IResult<T> NotFound<T>() {
        return new NotFoundResult<T>();
    }

    public static IResult Invalid(string error) {
        return new FailedValidationResult(new ValidationError(error));
    }

    public static IResult Invalid(ValidationError error) {
        return new FailedValidationResult(error);
    }

    public static IResult Invalid(IEnumerable<ValidationError> errors) {
        return new FailedValidationResult(errors);
    }

    public static IResult<T> Invalid<T>(string error) {
        return new FailedValidationResult<T>(new ValidationError(error));
    }

    public static IResult<T> Invalid<T>(ValidationError error) {
        return new FailedValidationResult<T>(error);
    }

    public static IResult<T> Invalid<T>(IEnumerable<ValidationError> errors) {
        return new FailedValidationResult<T>(errors);
    }
}