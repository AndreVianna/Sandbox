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
    }

    [Fact]
    public void InternalErrorResultOfT_WithException_IsCreated() {
        var exception = new InvalidOperationException("Some exception.");

        var subject = new InternalErrorResult<string>(exception);

        subject.Should().NotBeNull();
        subject.Value.Should().BeNull();
        subject.Exception.Should().BeEquivalentTo(exception);
    }
}