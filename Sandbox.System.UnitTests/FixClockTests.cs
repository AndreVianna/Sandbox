namespace System;

public class FixClockTests {
    [Fact]
    public void FixClock_Constructor_WithDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Local);

        var subject = new FixClock(date);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
    }

    [Fact]
    public void FixClock_Constructor_WithDecomposedDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Utc);

        var subject = new FixClock(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, DateTimeKind.Utc);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
    }

    [Fact]
    public void FixClock_Constructor_WithTicks_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Unspecified);

        var subject = new FixClock(date.Ticks, DateTimeKind.Unspecified);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(),"UtcNow differs.");
    }

    [Fact]
    public void FixClock_FromDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Local);

        var subject = FixClock.FromDateTime(date);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
    }

    [Fact]
    public void FixClock_FromDateTime_WithDecomposedDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Utc);

        var subject = FixClock.FromDateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, DateTimeKind.Utc);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
    }

    [Fact]
    public void FixClock_FromTicks_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Unspecified);

        var subject = FixClock.FromTicks(date.Ticks, DateTimeKind.Unspecified);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
    }
}
