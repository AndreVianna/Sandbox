namespace System.Validation;

public class ValidationErrorTests {
    [Fact]
    public void ValidationError_Constructor_WithAllProperties_CreatesObject() {
        var subject = new ValidationError("Message 1.", "Arg1", "Arg2") {
            Source = "SomeField",
        };

        subject.Should().NotBeNull();
        subject.Source.Should().Be("SomeField");
        subject.Message.Should().Be("Message 1.");
        subject.Arguments.Should().BeEquivalentTo(new object[] { "Arg1", "Arg2" });
    }

    [Fact]
    public void ValidationError_Constructor_WithMessageOnly_CreatesObject() {
        var subject = new ValidationError("Message 1");

        subject.Should().NotBeNull();
        subject.Source.Should().BeEmpty();
        subject.Message.Should().BeEquivalentTo("Message 1");
        subject.Arguments.Should().BeEmpty();
    }

    [Fact]
    public void ValidationError_Constructor_WithEmptyMessage_Throws() {
        var action = () => new ValidationError(" ");

        action.Should().Throw<ArgumentException>().WithMessage("Message cannot be null or empty. (Parameter 'message')");
    }
}
