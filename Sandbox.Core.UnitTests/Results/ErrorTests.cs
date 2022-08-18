﻿namespace System.Results;

public class ErrorTests {
    [Fact]
    public void Error_Record_Passes() {
        var subject = new Error("Message 1.", "Arg1", "Arg2") {
            Source = "SomeField",
        };

        subject.Should().NotBeNull();
        subject.Source.Should().Be("SomeField");
        subject.Message.Should().Be("Message 1.");
        subject.Arguments.Should().BeEquivalentTo(new object[] { "Arg1", "Arg2" });
    }

    [Fact]
    public void Error_WithMessageOnly_Passes() {
        var subject = new Error("Message 1");

        subject.Should().NotBeNull();
        subject.Source.Should().BeEmpty();
        subject.Message.Should().BeEquivalentTo("Message 1");
        subject.Arguments.Should().BeEmpty();
    }

    [Fact]
    public void Error_WithSourceAndEmptyMessages_Throws() {
        var action = () => new Error(" ");

        action.Should().Throw<ArgumentException>().WithMessage("Message cannot be null or empty. (Parameter 'message')");
    }
}