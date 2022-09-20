namespace System;

public class StaticClockTests {
    [Fact]
    public void StaticClock_Constructor_WithDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Local);

        var subject = new StaticClock(date);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
    }

    [Fact]
    public void StaticClock_Constructor_WithDecomposedDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Utc);

        var subject = new StaticClock(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, DateTimeKind.Utc);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
    }

    [Fact]
    public void StaticClock_Constructor_WithTicks_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Unspecified);

        var subject = new StaticClock(date.Ticks, DateTimeKind.Unspecified);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(),"UtcNow differs.");
    }

    [Fact]
    public void StaticClock_FromDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Local);

        var subject = StaticClock.FromDateTime(date);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
    }

    [Fact]
    public void StaticClock_FromDateTime_WithDecomposedDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Utc);

        var subject = StaticClock.FromDateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, DateTimeKind.Utc);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
    }

    [Fact]
    public void StaticClock_FromTicks_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Unspecified);

        var subject = StaticClock.FromTicks(date.Ticks, DateTimeKind.Unspecified);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
    }
}
