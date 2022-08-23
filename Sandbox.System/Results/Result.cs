﻿using System.Validation;

namespace System.Results;

public abstract record Result : IResult {
    public static IResult Ok() {
        return new SuccessfulResult();
    }

    public static IResult Ok<T>(T value) {
        return new SuccessfulResult<T>(value);
    }

    public static IResult Exception(Exception exception) {
        return new ExceptionalResult(exception);
    }

    public static IResult AlreadyExists() {
        return new ConflictingResult();
    }

    public static IResult ConflictsWith<T>(T value) {
        return new ConflictingResult<T>(value);
    }

    public static IResult NotFound() {
        return new NotFoundResult();
    }

    public static IResult InvalidBecause(string error) {
        return new FailedValidationResult(new ValidationError(error));
    }

    public static IResult InvalidBecause(ValidationError error) {
        return new FailedValidationResult(error);
    }

    public static IResult InvalidBecause(IEnumerable<ValidationError> errors) {
        return new FailedValidationResult(errors);
    }
}