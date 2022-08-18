namespace System.Results;

public class ConflictingResultTests {
    [Fact]
    public void ConflictingResult_DefaultConstructor_CreatesObject() {
        var subject = new ConflictingResult();

        subject.Should().NotBeNull();
    }

    [Fact]
    public void ConflictingResultOfT_Constructor_WithExistingValue_CreatesObject() {
        var subject = new SuccessfulResult<string>("Some value.");

        subject.Should().BeAssignableTo<SuccessfulResult>();
        subject.Should().NotBeNull();
        subject.Value.Should().Be("Some value.");
    }
}