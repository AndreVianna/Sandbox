namespace System;

public class SlidingClockTests {
    [Fact]
    public void SlidingClock_Constructor_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Utc);
        var interval = TimeSpan.FromSeconds(5);

        var subject = new SlidingClock(date, interval);

        var first = subject.UtcNow;
        var next1 = subject.UtcNow;
        var next2 = subject.Now;

        first.Should().Be(date, "Now differs.");
        next1.Should().Be(date + interval, "Next differs.");
        next2.Should().Be((date + (interval * 2)).ToLocalTime(), "Next differs.");
    }
}