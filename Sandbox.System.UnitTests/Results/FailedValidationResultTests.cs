using System.Validation;

namespace System.Results;

public class FailedValidationResultTests {
    [Fact]
    public void FailedValidationResult_Constructor_WithError_CreatesObject() {
        var error = new ValidationError("ValidationError B", "Arg1", "Arg2") { Source = "Source B" };
        var subject = new FailedValidationResult(error);

        subject.Should().NotBeNull();
        subject.Errors.Should().BeEquivalentTo(new[] { error });
    }

    [Fact]
    public void FailedValidationResult_Constructor_WithErrors_CreatesObject() {
        var errors = new ValidationError[] {
            new("ValidationError 1"),
            new("ValidationError A") { Source = "Source A" },
            new("ValidationError B", "Arg1", "Arg2") { Source = "Source B" }
        };
        var subject = new FailedValidationResult(errors);

        subject.Should().NotBeNull();
        subject.Errors.Should().BeEquivalentTo(errors);
    }

    [Fact]
    public void FailedValidationResult_Constructor_WithNullError_Throws() {
        var action = () => new FailedValidationResult(default(ValidationError)!);

        action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'error')");
    }

    [Fact]
    public void FailedValidationResult_Constructor_WithNullErrors_Throws() {
        var action = () => new FailedValidationResult(default(ValidationError[])!);

        action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'errors')");
    }

    [Fact]
    public void FailedValidationResult_Constructor_WithEmptyErrors_Throws() {
        var action = () => new FailedValidationResult(Array.Empty<ValidationError>());

        action.Should().Throw<ArgumentException>().WithMessage("ValidationError collection cannot be empty. (Parameter 'errors')");
    }

    [Fact]
    public void FailedValidationResult_Constructor_WithErrorArrayWithNullError_Throws() {
        var action = () => new FailedValidationResult(new ValidationError[] { null! });

        action.Should().Throw<ArgumentException>().WithMessage("ValidationError collection cannot contain a null element. (Parameter 'errors')");
    }
}
