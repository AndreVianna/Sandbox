namespace System;

public class DummyTimeProviderTests {
    private sealed class TestDateTimeProvider : DummyDateTimeProvider { }

    [Fact]
    public void DateTimeProvider_AllProperties_Throw() {
        var subject = new TestDateTimeProvider();

        ((Func<DateTime>)(() => subject.Now)).Should().Throw<NotImplementedException>();
        ((Func<DateTime>)(() => subject.UtcNow)).Should().Throw<NotImplementedException>();
        ((Func<DateTime>)(() => subject.Today)).Should().Throw<NotImplementedException>();
    }
}