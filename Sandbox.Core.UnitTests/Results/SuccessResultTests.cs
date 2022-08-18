namespace System.Results;

public class SuccessResultTests {
    [Fact]
    public void SuccessResult_Record_Passes() {
        var subject = new SuccessResult();

        subject.Should().NotBeNull();
        subject.Errors.Should().BeEmpty();
    }

    [Fact]
    public void SuccessResultOfT_Record_Passes() {
        var subject = new SuccessResult<string>("_") { Value = "Some value." };

        subject.Should().BeAssignableTo<SuccessResult>();
        subject.Should().NotBeNull();
        subject.Value.Should().Be("Some value.");
        subject.Errors.Should().BeEmpty();
    }
}
