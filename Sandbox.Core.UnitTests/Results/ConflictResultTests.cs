namespace System.Results;

public class ConflictResultTests {
    [Fact]
    public void ConflictResult_Record_Passes() {
        var subject = new ConflictResult();

        subject.Should().NotBeNull();
        subject.Errors.Should().BeEmpty();
    }

    [Fact]
    public void ConflictResultOfT_Record_Passes() {
        var subject = new ConflictResult<string>();

        subject.Should().BeAssignableTo<ConflictResult>();
        subject.Should().NotBeNull();
        subject.Value.Should().BeNull();
        subject.Errors.Should().BeEmpty();
    }
}