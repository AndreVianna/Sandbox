namespace System;

public class TemplatedStringTests {
    [Fact]
    public void TemplatedString_WithParameters_MessageHasFormattedText() {
        const string template = "Hello, {name}! Have {{ignored}} the {{{food}}}.";
        var arguments = new[] { "Billy", "sandwich" };
        const string expectedText = "Hello, Billy! Have {ignored} the {sandwich}.";
        const string otherText = "Hi, planet!.";
        var otherTemplate = new TemplatedString(template, arguments[0], arguments[1]);

        var subject = new TemplatedString(template, arguments[0], arguments[1]);

        subject.Should().NotBeNull();
        subject.Template.Should().Be(template);
        subject.Arguments.Should().BeEquivalentTo(arguments);
        subject.Formatted.Should().Be(expectedText);
        subject.GetHashCode().Should().Be(expectedText.GetHashCode());
        subject.ToString().Should().Be(expectedText);
        subject.Equals(expectedText).Should().BeTrue();
        subject.Equals(otherTemplate).Should().BeTrue();
        subject.CompareTo(otherText).Should().Be(string.CompareOrdinal(expectedText, otherText));
        subject.CompareTo(default).Should().Be(1);
        subject.CompareTo(default(string)).Should().Be(1);
        subject.CompareTo(otherTemplate).Should().Be(0);
        subject.CompareTo(default(TemplatedStringTests)).Should().Be(1);
    }

    [Fact]
    public void TemplatedString_ImplicitConversion_ReturnsString() {
        var template = new TemplatedString("Hello, {0}!.", "world");
        const string expectedResult = "Hello, world!.";

        string result = template;

        result.Should().Be(expectedResult);
    }

    [Fact]
    public void TemplatedString_CompareTo_CompareFormattedText() {
        var template = new TemplatedString("Hello, {0}!.", "world");
        var otherTemplate = new TemplatedString("Hi, {0}!.", "planet");
        const string message = "Hello, world!.";
        const string otherMessage = "Hi, planet!.";
        var stringComparison = string.CompareOrdinal(message, otherMessage);

        var subject = template.CompareTo(otherTemplate);

        subject.Should().Be(stringComparison);
    }

    [Fact]
    public void TemplatedString_CompareToNonStringOrTemplate_Throws() {
        var template = new TemplatedString("Hello, {0}!.", "world");

        var action = () => template.CompareTo(3);

        action.Should().Throw<ArgumentException>().WithMessage("Object must be of type String or TemplatedString.");
    }
}