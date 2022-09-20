namespace System;

public class VaryingClockTests {
    [Fact]
    public void VaryingClock_Constructor_WithDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Utc);
        TimeSpan Interval() => TimeSpan.FromSeconds(5);

        var subject = new VaryingClock(date, Interval);

        var first = subject.UtcNow;
        var next1 = subject.UtcNow;
        var next2 = subject.Now;

        first.Should().Be(date, "Now differs.");
        next1.Should().Be(date + Interval(), "Next differs.");
        next2.Should().Be((date + (Interval() * 2)).ToLocalTime(), "Next differs.");
    }
}