namespace System.Results;

public class NotFoundResultTests {
    [Fact]
    public void NotFoundResult_Record_Passes() {
        var subject = new NotFoundResult();

        subject.Should().NotBeNull();
        subject.Errors.Should().BeEmpty();
    }

    [Fact]
    public void NotFoundResultOfT_Record_Passes() {
        var subject = new NotFoundResult<string>();

        subject.Should().BeAssignableTo<NotFoundResult>();
        subject.Should().NotBeNull();
        subject.Value.Should().BeNull();
        subject.Errors.Should().BeEmpty();
    }
}
