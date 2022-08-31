namespace System;

public class ParameterizedStringTests {
    [Fact]
    public void ParameterizedString_WithParameters_MessageHasFormattedText() {
        const string template = "Hello, {name}! Have {{ignored}} the {{{food}}}.";
        var arguments = new[] { "Billy", "sandwich" };
        const string expectedText = "Hello, Billy! Have {ignored} the {sandwich}.";
        const string otherText = "Hi, planet!.";
        var otherTemplate = new ParameterizedString(template, arguments[0], arguments[1]);

        var subject = new ParameterizedString(template, arguments[0], arguments[1]);

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
        subject.CompareTo(default(ParameterizedStringTests)).Should().Be(1);
    }

    [Fact]
    public void ParameterizedString_Empty_ReturnsSingletonEmpty() {
        var first = ParameterizedString.Empty;
        var second = ParameterizedString.Empty;

        first.Template.Should().BeEmpty();
        first.Formatted.Should().BeEmpty();
        first.Arguments.Should().BeEmpty();

        first.Should().BeSameAs(second);
    }

    [Fact]
    public void ParameterizedString_Clone_ReturnsNewInstanceWithSameData() {
        const string template = "Hello, {name}! Have {{ignored}} the {{{food}}}.";
        var arguments = new object?[] { "Billy", "sandwich" };
        var source = new ParameterizedString(template, arguments);

        var result = source.Clone();

        var subject = result.Should().BeOfType<ParameterizedString>().Subject;
        subject.Template.Should().Be(template);
        subject.Arguments.Should().BeEquivalentTo(arguments);
        subject.Formatted.Should().Be(source.Formatted);

        subject.Should().NotBeSameAs(source);
    }

    [Fact]
    public void ParameterizedString_Create_ReturnsNewParameterizedString() {
        const string template = "Hello, {name}! Have {{ignored}} the {{{food}}}.";
        var arguments = new object?[] { "Billy", "sandwich" };
        const string expectedText = "Hello, Billy! Have {ignored} the {sandwich}.";

        var subject = ParameterizedString.Create(template, arguments);

        subject.Should().NotBeNull();
        subject.Template.Should().Be(template);
        subject.Arguments.Should().BeEquivalentTo(arguments);
        subject.Formatted.Should().Be(expectedText);
    }

    [Fact]
    public void ParameterizedString_ImplicitConversion_ReturnsString() {
        var template = new ParameterizedString("Hello, {0}!.", "world");
        const string expectedResult = "Hello, world!.";

        string result = template;

        result.Should().Be(expectedResult);
    }

    [Fact]
    public void ParameterizedString_CompareTo_CompareFormattedText() {
        var template = new ParameterizedString("Hello, {0}!.", "world");
        var otherTemplate = new ParameterizedString("Hi, {0}!.", "planet");
        const string message = "Hello, world!.";
        const string otherMessage = "Hi, planet!.";
        var stringComparison = string.CompareOrdinal(message, otherMessage);

        var subject = template.CompareTo(otherTemplate);

        subject.Should().Be(stringComparison);
    }

    [Fact]
    public void ParameterizedString_CompareToNonStringOrTemplate_Throws() {
        var template = new ParameterizedString("Hello, {0}!.", "world");

        var action = () => template.CompareTo(3);

        action.Should().Throw<ArgumentException>().WithMessage("Object must be of type String or ParameterizedString.");
    }
}