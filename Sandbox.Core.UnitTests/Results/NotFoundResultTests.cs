namespace System.Results;

public class NotFoundResultTests {
    [Fact]
    public void NotFoundResult_DefaultConstructor_CreatesObject() {
        var subject = new NotFoundResult();

        subject.Should().NotBeNull();
    }
}
