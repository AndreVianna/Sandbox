namespace System.Results;

public class FailedValidationResultTests {
    [Fact]
    public void FailedValidationResult_Constructor_WithError_CreatesObject() {
        var error = new Error("Error B", "Arg1", "Arg2") { Source = "Source B" };
        var subject = new FailedValidationResult(error);

        subject.Should().NotBeNull();
        subject.Errors.Should().BeEquivalentTo(new[] { error });
    }

    [Fact]
    public void FailedValidationResult_Constructor_WithErrors_CreatesObject() {
        var errors = new Error[] {
            new("Error 1"),
            new("Error A") { Source = "Source A" },
            new("Error B", "Arg1", "Arg2") { Source = "Source B" }
        };
        var subject = new FailedValidationResult(errors);

        subject.Should().NotBeNull();
        subject.Errors.Should().BeEquivalentTo(errors);
    }

    [Fact]
    public void FailedValidationResult_Constructor_WithNullError_Throws() {
        var action = () => new FailedValidationResult(default(Error)!);

        action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'error')");
    }

    [Fact]
    public void FailedValidationResult_Constructor_WithNullErrors_Throws() {
        var action = () => new FailedValidationResult(default(Error[])!);

        action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'errors')");
    }

    [Fact]
    public void FailedValidationResult_Constructor_WithEmptyErrors_Throws() {
        var action = () => new FailedValidationResult(Array.Empty<Error>());

        action.Should().Throw<ArgumentException>().WithMessage("Error collection cannot be empty. (Parameter 'errors')");
    }

    [Fact]
    public void FailedValidationResult_Constructor_WithErrorArrayWithNullError_Throws() {
        var action = () => new FailedValidationResult(new Error[] { null! });

        action.Should().Throw<ArgumentException>().WithMessage("Error collection cannot contain a null element. (Parameter 'errors')");
    }
}
