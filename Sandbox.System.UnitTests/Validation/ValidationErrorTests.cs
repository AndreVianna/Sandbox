namespace System.Validation;

public class ValidationErrorTests {
    [Fact]
    public void ValidationError_Constructor_WithAllProperties_CreatesObject() {
        var subject = new ValidationError("Message 1 {arg1} {arg2}.", "Arg1", "Arg2") {
            Source = "SomeField",
            Code = "ERR001T",
        };

        subject.Should().NotBeNull();
        subject.Source.Should().Be("SomeField");
        subject.Code.Should().Be("ERR001T");
        subject.Message.Template.Should().Be("Message 1 {arg1} {arg2}.");
        subject.Message.Arguments.Should().BeEquivalentTo(new[] { "Arg1", "Arg2" });
        subject.Message.Formatted.Should().Be("Message 1 Arg1 Arg2.");
    }

    [Fact]
    public void ValidationError_Constructor_WithMessageOnly_CreatesObject() {
        var subject = new ValidationError("Message 1");

        subject.Should().NotBeNull();
        subject.Source.Should().BeEmpty();
        subject.Code.Should().Be("Message 1");
        subject.Message.Template.Should().Be("Message 1");
        subject.Message.Arguments.Should().BeEmpty();
        subject.Message.Formatted.Should().Be("Message 1");
    }

    [Fact]
    public void ValidationError_Constructor_WithEmptyMessage_Throws() {
        var action = () => new ValidationError(" ");

        action.Should().Throw<ArgumentException>().WithMessage("Message cannot be null or empty. (Parameter 'message')");
    }

    [Fact]
    public void ValidationError_Constructor_WithEmptyFormat_Throws() {
        var action = () => new ValidationError(" ", "Arg1");

        action.Should().Throw<ArgumentException>().WithMessage("Message format cannot be null or empty. (Parameter 'format')");
    }
}
