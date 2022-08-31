namespace System;

public class StringFormatterTests {
    [Fact]
    public void StringFormatter_WithoutParameters_MessageHasFormattedText() {
        const string template = "Hello, world!.";

        var subject = StringFormatter.Format(template);

        subject.Should().Be(template);
    }

    [Fact]
    public void StringFormatter_WithParameters_MessageHasFormattedText() {
        const string expectedMessage = "1, {ignored}, {2}, 1";

        var subject = StringFormatter.Format("{one}, {{ignored}}, {{{two}}}, {one}", "1", 2);

        subject.Should().Be(expectedMessage);
    }

    [Fact]
    public void StringFormatter_WithLessInputsThanParameters_Throws() {
        var action = () => StringFormatter.Format("{one}, {two}, {three}.", "one", "two");

        action.Should().Throw<ArgumentException>();
    }
}