namespace System;

public class FixedClockTests {
    [Fact]
    public void FixedClock_Constructor_WithDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Local);

        var subject = new FixedClock(date);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
    }

    [Fact]
    public void FixedClock_Constructor_WithDecomposedDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Utc);

        var subject = new FixedClock(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, DateTimeKind.Utc);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
    }

    [Fact]
    public void FixedClock_Constructor_WithTicks_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Unspecified);

        var subject = new FixedClock(date.Ticks, DateTimeKind.Unspecified);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(),"UtcNow differs.");
    }

    [Fact]
    public void FixedClock_FromDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Local);

        var subject = FixedClock.FromDateTime(date);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
    }

    [Fact]
    public void FixedClock_FromDateTime_WithDecomposedDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Utc);

        var subject = FixedClock.FromDateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, DateTimeKind.Utc);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
    }

    [Fact]
    public void FixedClock_FromTicks_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Unspecified);

        var subject = FixedClock.FromTicks(date.Ticks, DateTimeKind.Unspecified);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
    }
}
