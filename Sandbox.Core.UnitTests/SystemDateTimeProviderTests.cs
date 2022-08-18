namespace System;

public class SystemDateTimeProviderTests {
    private static readonly TimeSpan _tolerance = TimeSpan.FromMilliseconds(5);

    [Fact]
    public void SystemDateTimeProvider_UtcNow_Passes() {
        var provider = new SystemDateTimeProvider();

        var subject = provider.UtcNow;

        subject.Should().BeCloseTo(DateTime.UtcNow, _tolerance);
    }

    [Fact]
    public void SystemDateTimeProvider_UtcToday_Passes() {
        var provider = new SystemDateTimeProvider();

        var subject = provider.UtcToday;

        subject.Should().Be(DateOnly.FromDateTime(DateTime.UtcNow));
    }
    [Fact]
    public void SystemDateTimeProvider_Now_Passes() {
        var provider = new SystemDateTimeProvider();

        var subject = provider.Now;

        subject.Should().BeCloseTo(DateTime.Now, _tolerance);
    }

    [Fact]
    public void SystemDateTimeProvider_Today_Passes() {
        var provider = new SystemDateTimeProvider();

        var subject = provider.Today;

        subject.Should().Be(DateOnly.FromDateTime(DateTime.Now));
    }
}