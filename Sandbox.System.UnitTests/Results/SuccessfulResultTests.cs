namespace System.Results;

public class SuccessfulResultTests {
    [Fact]
    public void SuccessfulResult_DefaultConstructor_CreatesObject() {
        var subject = new SuccessfulResult();

        subject.Should().BeAssignableTo<IResult>();
        subject.Should().NotBeNull();
    }

    [Fact]
    public void SuccessfulResultOfT_Constructor_WithValue_CreatesObject() {
        var subject = new SuccessfulResultFor<string>("Some value.");

        subject.Should().BeAssignableTo<IResult<string>>();
        subject.Should().NotBeNull();
        subject.Value.Should().Be("Some value.");
    }
}