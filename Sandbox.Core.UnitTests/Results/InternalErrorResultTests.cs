namespace System.Results;

public class InternalErrorResultTests {
    [Fact]
    public void InternalErrorResult_WithNullException_Throws() {
        var action = () => new InternalErrorResult(null!);

        action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'exception')");
    }

    [Fact]
    public void InternalErrorResult_WithException_IsCreated() {
        var exception = new InvalidOperationException("Some exception.");

        var subject = new InternalErrorResult(exception);

        subject.Should().NotBeNull();
        subject.Exception.Should().BeEquivalentTo(exception);
        subject.Errors.Should().BeEmpty();
    }

    [Fact]
    public void InternalErrorResult_WithNullExceptionAndError_Throws() {
        var error = new Error("Error B", "Arg1", "Arg2") { Source = "Source B" };

        var action = () => new InternalErrorResult(null!, error);

        action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'exception')");
    }

    [Fact]
    public void InternalErrorResult_WithError_IsCreated() {
        var exception = new InvalidOperationException("Some exception.");
        var error = new Error("Error B", "Arg1", "Arg2") { Source = "Source B" };

        var subject = new InternalErrorResult(exception, error);

        subject.Should().NotBeNull();
        subject.Exception.Should().BeEquivalentTo(exception);
        subject.Errors.Should().BeEquivalentTo(new[] { error });
    }


    [Fact]
    public void InternalErrorResult_WithNullExceptionAndErrorArray_Throws() {
        var errors = new Error[] {
            new("Error 1"),
            new("Error A") { Source = "Source A" },
            new("Error B", "Arg1", "Arg2") { Source = "Source B" }
        };

        var action = () => new InternalErrorResult(null!, errors);

        action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'exception')");
    }

    [Fact]
    public void InternalErrorResult_WithErrorArray_IsCreated() {
        var exception = new InvalidOperationException("Some exception.");
        var errors = new Error[] {
            new("Error 1"),
            new("Error A") { Source = "Source A" },
            new("Error B", "Arg1", "Arg2") { Source = "Source B" }
        };

        var subject = new InternalErrorResult(exception, errors);

        subject.Should().NotBeNull();
        subject.Exception.Should().BeEquivalentTo(exception);
        subject.Errors.Should().BeEquivalentTo(errors);
    }

    [Fact]
    public void InternalErrorResult_WithEmptyErrorArray_IsCreated() {
        var exception = new InvalidOperationException("Some exception.");
        var errors = Array.Empty<Error>();

        var subject = new InternalErrorResult(exception, errors);

        subject.Should().NotBeNull();
        subject.Exception.Should().BeEquivalentTo(exception);
        subject.Errors.Should().BeEmpty();
    }

    [Fact]
    public void InternalErrorResultOfT_WithException_IsCreated() {
        var exception = new InvalidOperationException("Some exception.");

        var subject = new InternalErrorResult<string>(exception);

        subject.Should().NotBeNull();
        subject.Value.Should().BeNull();
        subject.Exception.Should().BeEquivalentTo(exception);
        subject.Errors.Should().BeEmpty();
    }

    [Fact]
    public void InternalErrorResultOfT_WithError_IsCreated() {
        var exception = new InvalidOperationException("Some exception.");
        var error = new Error("Error B", "Arg1", "Arg2") { Source = "Source B" };

        var subject = new InternalErrorResult<string>(exception, error);

        subject.Should().NotBeNull();
        subject.Value.Should().BeNull();
        subject.Exception.Should().BeEquivalentTo(exception);
        subject.Errors.Should().BeEquivalentTo(new[] { error });
    }

    [Fact]
    public void InternalErrorResultOfT_WithErrorArray_IsCreated() {
        var exception = new InvalidOperationException("Some exception.");
        var errors = new Error[] {
            new("Error 1"),
            new("Error A") { Source = "Source A" },
            new("Error B", "Arg1", "Arg2") { Source = "Source B" }
        };

        var subject = new InternalErrorResult<string>(exception, errors);

        subject.Should().NotBeNull();
        subject.Value.Should().BeNull();
        subject.Exception.Should().BeEquivalentTo(exception);
        subject.Errors.Should().BeEquivalentTo(errors);
    }

    [Fact]
    public void InternalErrorResultOfT_WithEmptyErrorArray_IsCreated() {
        var exception = new InvalidOperationException("Some exception.");
        var errors = Array.Empty<Error>();

        var subject = new InternalErrorResult<string>(exception, errors);

        subject.Should().NotBeNull();
        subject.Value.Should().BeNull();
        subject.Exception.Should().BeEquivalentTo(exception);
        subject.Errors.Should().BeEmpty();
    }
}