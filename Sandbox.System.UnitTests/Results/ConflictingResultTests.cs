namespace System.Results;

public class ConflictingResultTests {
    [Fact]
    public void ConflictingResult_DefaultConstructor_CreatesObject() {
        var subject = new ConflictingResult();

        subject.Should().NotBeNull();
    }

    [Fact]
    public void ConflictingResult_Constructor_WithReason_CreatesObject() {
        var subject = new ConflictingResult("Some reason.");

        subject.Should().BeAssignableTo<FailedResult>();
        subject.Should().NotBeNull();
        subject.Reason.Should().Be("Some reason.");
    }

    [Fact]
    public void ConflictingResultOfT_DefaultConstructor_CreatesObject() {
        var subject = new ConflictingResult<string>();

        subject.Should().BeAssignableTo<FailedResult<string>>();
        subject.Should().NotBeNull();
    }

    [Fact]
    public void ConflictingResultOfT_Constructor_WithExistingValue_CreatesObject() {
        var subject = new ConflictingResult<string>("Some reason.");

        subject.Should().BeAssignableTo<FailedResult<string>>();
        subject.Should().NotBeNull();
        subject.Reason.Should().Be("Some reason.");
        subject.Value.Should().BeNull();
    }
}