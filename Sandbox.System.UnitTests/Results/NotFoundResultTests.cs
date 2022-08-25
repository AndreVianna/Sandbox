namespace System.Results;

public class NotFoundResultTests {
    [Fact]
    public void NotFoundResult_DefaultConstructor_CreatesObject() {
        var subject = new NotFoundResult();

        subject.Should().BeAssignableTo<FailedResult>();
        subject.Should().NotBeNull();
    }

    [Fact]
    public void NotFoundResultOfT_DefaultConstructor_CreatesObject() {
        var subject = new NotFoundResult<string>();

        subject.Should().BeAssignableTo<FailedResult<string>>();
        subject.Should().NotBeNull();
        subject.Value.Should().BeNull();
    }
}