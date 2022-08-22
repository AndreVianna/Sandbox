namespace System;

public class NothingTests {
    [Fact]
    public void Nothing_ShouldBeASingleton() {
        var subject = Nothing.Instance;
        var other = Nothing.Instance;

        subject.Should().BeSameAs(other);
        subject.ToString().Should().Be("[Nothing]");
    }
}