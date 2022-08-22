namespace System.Results;

public class SuccessfulResultTests {
    [Fact]
    public void SuccessfulResult_DefaultConstructor_CreatesObject() {
        var subject = new SuccessfulResult();

        subject.Should().NotBeNull();
    }

    [Fact]
    public void SuccessfulResultOfT_Constructor_WithValue_CreatesObject() {
        var subject = new SuccessfulResult<string>("Some value.");

        subject.Should().BeAssignableTo<SuccessfulResult>();
        subject.Should().NotBeNull();
        subject.Value.Should().Be("Some value.");
    }
}
