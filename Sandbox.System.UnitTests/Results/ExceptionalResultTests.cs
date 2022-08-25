namespace System.Results;

public class ExceptionalResultTests {
    [Fact]
    public void ExceptionalResult_Constructor_WithException_CreatesObject() {
        var exception = new InvalidOperationException("Some exception.");

        var subject = new ExceptionalResult(exception);

        subject.Should().BeAssignableTo<FailedResult>();
        subject.Should().NotBeNull();
        subject.Exception.Should().BeEquivalentTo(exception);
    }

    [Fact]
    public void ExceptionalResult_Constructor_WithNullException_Throws() {
        var action = () => new ExceptionalResult(null!);

        action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'exception')");
    }

    [Fact]
    public void ExceptionalResult_Throw_ThrowsException() {
        var exception = new InvalidOperationException("Some exception.");

        var subject = new ExceptionalResult(exception);

        var action = () => subject.Throw();

        action.Should().Throw<InvalidOperationException>().WithMessage("Some exception.");
    }

    [Fact]
    public void ExceptionalResultOfT_Constructor_WithException_CreatesObject() {
        var exception = new InvalidOperationException("Some exception.");

        var subject = new ExceptionalResult<string>(exception);

        subject.Should().BeAssignableTo<FailedResult<string>>();
        subject.Should().NotBeNull();
        subject.Exception.Should().BeEquivalentTo(exception);
        subject.Value.Should().BeNull();
    }

    [Fact]
    public void ExceptionalResultOfT_Constructor_WithNullException_Throws() {
        var action = () => new ExceptionalResult<string>(null!);

        action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'exception')");
    }

    [Fact]
    public void ExceptionalResultOfT_Throw_ThrowsException() {
        var exception = new InvalidOperationException("Some exception.");

        var subject = new ExceptionalResult<string>(exception);

        var action = () => subject.Throw();

        action.Should().Throw<InvalidOperationException>().WithMessage("Some exception.");
    }
}