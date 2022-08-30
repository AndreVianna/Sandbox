namespace System;

public class TemplatedStringTests {
    [Fact]
    public void TemplatedString_Message_HasFormattedTemplate() {
        const string template = "Hello, {name}! Have {{ignored}} the {{{food}}}.";
        var items = new[] { "Billy", "sandwich" };
        const string expectedMessage = "Hello, Billy! Have {ignored} the {sandwich}.";
        var expectedArguments = new Dictionary<string, object?> { ["name"] = "Billy", ["food"] = "sandwich" };

        var subject = new TemplatedString(template, items[0], items[1]);

        subject.Template.Should().Be(template);
        subject.Arguments.Should().BeEquivalentTo(expectedArguments);
        subject.Formatted.Should().Be(expectedMessage);
    }

    [Fact]
    public void TemplatedString_WhenTemplateHasNoItems_Message_HasTemplate() {
        const string template = "Hello, world!.";
        const string expectedMessage = "Hello, world!.";

        var subject = new TemplatedString(template);

        subject.Template.Should().Be(template);
        subject.Arguments.Should().BeEmpty();
        subject.Formatted.Should().Be(expectedMessage);
    }
}