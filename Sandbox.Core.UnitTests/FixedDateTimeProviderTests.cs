namespace System;

public class FixedDateTimeProviderTests {
    [Fact]
    public void FixedDateTimeProvider_Constructor_WithDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Local);

        var subject = new FixedDateTimeProvider(date);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
        subject.Today.Should().Be(subject.Now.Date, "Today differs.");
    }

    [Fact]
    public void FixedDateTimeProvider_Constructor_WithDecomposedDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Utc);

        var subject = new FixedDateTimeProvider(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, DateTimeKind.Utc);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
        subject.Today.Should().Be(subject.Now.Date, "Today differs.");
    }

    [Fact]
    public void FixedDateTimeProvider_Constructor_WithTicks_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Unspecified);

        var subject = new FixedDateTimeProvider(date.Ticks, DateTimeKind.Unspecified);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(),"UtcNow differs.");
        subject.Today.Should().Be(subject.Now.Date, "Today differs.");
    }

    [Fact]
    public void FixedDateTimeProvider_FromDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Local);

        var subject = FixedDateTimeProvider.FromDateTime(date);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
        subject.Today.Should().Be(subject.Now.Date, "Today differs.");
    }

    [Fact]
    public void FixedDateTimeProvider_FromDateTime_WithDecomposedDateTime_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Utc);

        var subject = FixedDateTimeProvider.FromDateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, DateTimeKind.Utc);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
        subject.Today.Should().Be(subject.Now.Date, "Today differs.");
    }

    [Fact]
    public void FixedDateTimeProvider_FromTicks_CreatesObject() {
        var date = new DateTime(1985, 07, 03, 01, 23, 45, 678, DateTimeKind.Unspecified);

        var subject = FixedDateTimeProvider.FromTicks(date.Ticks, DateTimeKind.Unspecified);

        subject.Now.Should().Be(date.ToLocalTime(), "Now differs.");
        subject.UtcNow.Should().Be(date.ToUniversalTime(), "UtcNow differs.");
        subject.Today.Should().Be(subject.Now.Date, "Today differs.");
    }
}
