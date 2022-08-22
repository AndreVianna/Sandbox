namespace System.Results;

public class ExceptionalResultTests {
    [Fact]
    public void ExceptionalResult_Constructor_WithException_CreatesObject() {
        var exception = new InvalidOperationException("Some exception.");

        var subject = new ExceptionalResult(exception);

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
}