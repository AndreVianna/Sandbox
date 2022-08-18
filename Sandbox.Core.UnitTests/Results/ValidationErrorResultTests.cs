namespace System.Results;

public class ValidationErrorResultTests {
    private static readonly Error[] _expectedErrors = {
        new("Error 1"),
        new("Error A") { Source = "Source A" },
        new("Error B", "Arg1", "Arg2") { Source = "Source B" }
    };

    [Fact]
    public void ValidationErrorResult_Record_WithError_Passes() {
        var error = new Error("Error B", "Arg1", "Arg2") { Source = "Source B" };
        var subject = new ValidationErrorResult(error);

        subject.Should().NotBeNull();
        subject.Errors.Should().BeEquivalentTo(new[] { _expectedErrors[2] });
    }

    [Fact]
    public void ValidationErrorResult_Record_WithErrorArray_Passes() {
        var errors = new Error[] {
            new("Error 1"),
            new("Error A") { Source = "Source A" },
            new("Error B", "Arg1", "Arg2") { Source = "Source B" }
        };
        var subject = new ValidationErrorResult(errors);

        subject.Should().NotBeNull();
        subject.Errors.Should().BeEquivalentTo(_expectedErrors);
    }

    [Fact]
    public void ValidationErrorResult_WithNullError_Throws() {
        var action = () => new ValidationErrorResult(default(Error)!);

        action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'error')");
    }

    [Fact]
    public void ValidationErrorResult_WithNullErrors_Throws() {
        var action = () => new ValidationErrorResult(default(Error[])!);

        action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'errors')");
    }

    [Fact]
    public void ValidationErrorResult_WithEmptyErrors_Throws() {
        var action = () => new ValidationErrorResult(Array.Empty<Error>());

        action.Should().Throw<ArgumentException>().WithMessage("Collection cannot be empty. (Parameter 'errors')");
    }

    [Fact]
    public void ValidationErrorResult_WithErrorArrayWithNullError_Throws() {
        var action = () => new ValidationErrorResult(new Error[] { null! });

        action.Should().Throw<ArgumentException>().WithMessage("Collection cannot contain a null element. (Parameter 'errors')");
    }

    [Fact]
    public void ValidationErrorResultOfT_Record_WithError_Passes() {
        var error = new Error("Error 1");
        var subject = new ValidationErrorResult<string>(error);

        subject.Should().BeAssignableTo<ValidationErrorResult>();
        subject.Should().NotBeNull();
        subject.Value.Should().BeNull();
        subject.Errors.Should().BeEquivalentTo(new[] { _expectedErrors[0] });
    }

    [Fact]
    public void ValidationErrorResultOfT_Record_WithErrorList_Passes() {
        var errors = new List<Error>();
        errors.AddRange(new Error[] {
            new("Error 1"),
            new("Error A") { Source = "Source A" },
        });
        errors.Add(new("Error B", "Arg1", "Arg2") { Source = "Source B" });
        var subject = new ValidationErrorResult<string>(errors);

        subject.Should().NotBeNull();
        subject.Value.Should().BeNull();
        subject.Errors.Should().BeEquivalentTo(_expectedErrors);
    }
}
