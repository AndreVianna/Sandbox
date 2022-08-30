using System.Validation;

namespace System.Results;

public class ResultTests {
    [Fact]
    public void Result_Success_ReturnsSuccessfulResult() {
        var subject = Result.Success();

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().BeOfType<SuccessfulResult>();
    }

    [Fact]
    public void Result_SuccessOfT_ReturnsSuccessfulResultOfT() {
        var subject = Result.Success("Some value");

        subject.Should().BeAssignableTo<IResult<string>>();
        var result = subject.Should().BeOfType<SuccessfulResultFor<string>>().Subject;
        result.Value.Should().Be("Some value");
    }

    [Fact]
    public void Result_Exception_ReturnsExceptionalResult() {
        var exception = new InvalidOperationException("Some exception.");
        var subject = Result.Exception(exception);

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().BeAssignableTo<FailedResult>();
        var result = subject.Should().BeOfType<ExceptionalResult>().Subject;
        result.Exception.Should().BeEquivalentTo(exception);
    }

    [Fact]
    public void Result_ExceptionOfT_ReturnsExceptionalResult() {
        var exception = new InvalidOperationException("Some exception.");
        var subject = Result.Exception<string>(exception);

        subject.Should().BeAssignableTo<IResult<string>>();
        subject.Should().BeAssignableTo<FailedResult<string>>();
        var result = subject.Should().BeOfType<ExceptionalResult<string>>().Subject;
        result.Exception.Should().BeEquivalentTo(exception);
    }

    [Fact]
    public void Result_Conflict_ReturnsConflictingResult() {
        var subject = Result.Conflict("Some reason.");

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().BeAssignableTo<FailedResult>();
        var result = subject.Should().BeOfType<ConflictingResult>().Subject;
        result.Reason.Should().Be("Some reason.");
    }

    [Fact]
    public void Result_ConflictOfT_ReturnsConflictingResultOfT() {
        var subject = Result.Conflict<string>("Some reason.");

        subject.Should().BeAssignableTo<IResult<string>>();
        subject.Should().BeAssignableTo<FailedResult<string>>();
        var result = subject.Should().BeOfType<ConflictingResult<string>>().Subject;
        result.Reason.Should().Be("Some reason.");
    }

    [Fact]
    public void Result_NotFound_ReturnsNotFoundResult() {
        var subject = Result.NotFound();

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().BeAssignableTo<FailedResult>();
        subject.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public void Result_NotFoundOfT_ReturnsNotFoundResult() {
        var subject = Result.NotFound<string>();

        subject.Should().BeAssignableTo<IResult<string>>();
        subject.Should().BeAssignableTo<FailedResult<string>>();
        subject.Should().BeOfType<NotFoundResult<string>>();
    }

    [Fact]
    public void Result_Invalid_WithMessage_ReturnsFailedValidationResult() {
        var subject = Result.Invalid("Some error.");

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().BeAssignableTo<FailedResult>();
        var result = subject.Should().BeOfType<FailedValidationResult>().Subject;
        result.Errors.Should().HaveCount(1);
        result.Errors[0].Message.Arguments.Should().BeEmpty();
        result.Errors[0].Message.Template.Should().Be("Some error.");
        result.Errors[0].Message.Formatted.Should().Be("Some error.");
        result.Errors[0].Source.Should().BeEmpty();
        result.Errors[0].Code.Should().Be("Some error.");
    }

    [Fact]
    public void Result_Invalid_WithError_ReturnsFailedValidationResult() {
        var subject = Result.Invalid(new ValidationError("Some error."));

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().BeAssignableTo<FailedResult>();
        var result = subject.Should().BeOfType<FailedValidationResult>().Subject;
        result.Errors.Should().HaveCount(1);
        result.Errors[0].Message.Arguments.Should().BeEmpty();
        result.Errors[0].Message.Template.Should().Be("Some error.");
        result.Errors[0].Message.Formatted.Should().Be("Some error.");
        result.Errors[0].Source.Should().BeEmpty();
        result.Errors[0].Code.Should().Be("Some error.");
    }

    [Fact]
    public void Result_Invalid_WithErrorList_ReturnsFailedValidationResult() {
        var subject = Result.Invalid(new[] { new ValidationError("Some error."), new ValidationError("Other error.") });

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().BeAssignableTo<FailedResult>();
        var result = subject.Should().BeOfType<FailedValidationResult>().Subject;
        result.Errors.Should().HaveCount(2);
        result.Errors[0].Message.Arguments.Should().BeEmpty();
        result.Errors[0].Message.Template.Should().Be("Some error.");
        result.Errors[0].Message.Formatted.Should().Be("Some error.");
        result.Errors[0].Source.Should().BeEmpty();
        result.Errors[0].Code.Should().Be("Some error.");
        result.Errors[1].Message.Arguments.Should().BeEmpty();
        result.Errors[1].Message.Template.Should().Be("Other error.");
        result.Errors[1].Message.Formatted.Should().Be("Other error.");
        result.Errors[1].Source.Should().BeEmpty();
        result.Errors[1].Code.Should().Be("Other error.");
    }

    [Fact]
    public void Result_InvalidOfT_WithMessage_ReturnsFailedValidationResult() {
        var subject = Result.Invalid<string>("Some error.");

        subject.Should().BeAssignableTo<IResult<string>>();
        subject.Should().BeAssignableTo<FailedResult<string>>();
        var result = subject.Should().BeOfType<FailedValidationResult<string>>().Subject;
        result.Errors.Should().HaveCount(1);
        result.Errors[0].Message.Arguments.Should().BeEmpty();
        result.Errors[0].Message.Template.Should().Be("Some error.");
        result.Errors[0].Message.Formatted.Should().Be("Some error.");
        result.Errors[0].Source.Should().BeEmpty();
        result.Errors[0].Code.Should().Be("Some error.");
    }

    [Fact]
    public void Result_InvalidOfT_WithError_ReturnsFailedValidationResult() {
        var subject = Result.Invalid<string>(new ValidationError("Some error."));

        subject.Should().BeAssignableTo<IResult<string>>();
        subject.Should().BeAssignableTo<FailedResult<string>>();
        var result = subject.Should().BeOfType<FailedValidationResult<string>>().Subject;
        result.Errors.Should().HaveCount(1);
        result.Errors[0].Message.Arguments.Should().BeEmpty();
        result.Errors[0].Message.Template.Should().Be("Some error.");
        result.Errors[0].Message.Formatted.Should().Be("Some error.");
        result.Errors[0].Source.Should().BeEmpty();
        result.Errors[0].Code.Should().Be("Some error.");
    }

    [Fact]
    public void Result_InvalidOfT_WithErrorList_ReturnsFailedValidationResult() {
        var subject = Result.Invalid<string>(new[] { new ValidationError("Some error."), new ValidationError("Other error.") });

        subject.Should().BeAssignableTo<IResult<string>>();
        subject.Should().BeAssignableTo<FailedResult<string>>();
        var result = subject.Should().BeOfType<FailedValidationResult<string>>().Subject;
        result.Errors.Should().HaveCount(2);
        result.Errors[0].Message.Arguments.Should().BeEmpty();
        result.Errors[0].Message.Template.Should().Be("Some error.");
        result.Errors[0].Message.Formatted.Should().Be("Some error.");
        result.Errors[0].Source.Should().BeEmpty();
        result.Errors[0].Code.Should().Be("Some error.");
        result.Errors[1].Message.Arguments.Should().BeEmpty();
        result.Errors[1].Message.Template.Should().Be("Other error.");
        result.Errors[1].Message.Formatted.Should().Be("Other error.");
        result.Errors[1].Source.Should().BeEmpty();
        result.Errors[1].Code.Should().Be("Other error.");
    }
}