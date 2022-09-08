namespace System;

public class DummyClockTests {
    private sealed class TestClock : DummyClock { }

    [Fact]
    public void DummyClock_AllProperties_Throw() {
        var subject = new TestClock();

        ((Func<DateTime>)(() => subject.Now)).Should().Throw<NotImplementedException>();
        ((Func<DateTime>)(() => subject.UtcNow)).Should().Throw<NotImplementedException>();
    }
}