namespace System.Results;

public class ResultTests {
    [Fact]
    public void Result_Ok_ReturnsSuccessfulResult() {
        var subject = Result.Ok();

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().BeAssignableTo<Result>();
        subject.Should().BeOfType<SuccessfulResult>();
    }

    [Fact]
    public void Result_OkOfT_ReturnsSuccessfulResultOfT() {
        var subject = Result.Ok("Some value");

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().BeAssignableTo<Result>();
        subject.Should().BeAssignableTo<SuccessfulResult>();
        var result = subject.Should().BeOfType<SuccessfulResult<string>>().Subject;
        result.Value.Should().Be("Some value");
    }

    [Fact]
    public void Result_Exception_ReturnsExceptionalResult() {
        var exception = new InvalidOperationException("Some exception.");
        var subject = Result.Exception(exception);

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().BeAssignableTo<Result>();
        var result = subject.Should().BeOfType<ExceptionalResult>().Subject;
        result.Exception.Should().BeEquivalentTo(exception);
    }

    [Fact]
    public void Result_AlreadyExists_ReturnsConflictingResult() {
        var subject = Result.AlreadyExists();

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().BeAssignableTo<Result>();
        subject.Should().BeAssignableTo<FailedResult>();
        subject.Should().BeOfType<ConflictingResult>();
    }

    [Fact]
    public void Result_ConflictsWith_ReturnsConflictingResultOfT() {
        var subject = Result.ConflictsWith("Other value");

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().BeAssignableTo<Result>();
        subject.Should().BeAssignableTo<FailedResult>();
        subject.Should().BeAssignableTo<ConflictingResult>();
        var result = subject.Should().BeOfType<ConflictingResult<string>>().Subject;
        result.ExistingValue.Should().Be("Other value");
    }

    [Fact]
    public void Result_NotFound_ReturnsNotFoundResult() {
        var subject = Result.NotFound();

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().BeAssignableTo<Result>();
        subject.Should().BeAssignableTo<FailedResult>();
        subject.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public void Result_InvalidBecause_WithMessage_ReturnsFailedValidationResult() {
        var subject = Result.InvalidBecause("Some error.");

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().BeAssignableTo<Result>();
        subject.Should().BeAssignableTo<FailedResult>();
        var result = subject.Should().BeOfType<FailedValidationResult>().Subject;
        result.Errors.Should().BeEquivalentTo(new[] { new Error("Some error.") });
    }

    [Fact]
    public void Result_InvalidBecause_WithError_ReturnsFailedValidationResult() {
        var subject = Result.InvalidBecause(new Error("Some error."));

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().BeAssignableTo<Result>();
        subject.Should().BeAssignableTo<FailedResult>();
        var result = subject.Should().BeOfType<FailedValidationResult>().Subject;
        result.Errors.Should().BeEquivalentTo(new[] { new Error("Some error.") });
    }

    [Fact]
    public void Result_InvalidBecause_WithErrorList_ReturnsFailedValidationResult() {
        var subject = Result.InvalidBecause(new[] { new Error("Some error."), new Error("Other error.") });

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().BeAssignableTo<Result>();
        subject.Should().BeAssignableTo<FailedResult>();
        var result = subject.Should().BeOfType<FailedValidationResult>().Subject;
        result.Errors.Should().BeEquivalentTo(new[] { new Error("Some error."), new Error("Other error.") });
    }
}