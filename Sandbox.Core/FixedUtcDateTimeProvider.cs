using System.Globalization;

namespace System;

public class FixedUtcDateTimeProvider : IDateTimeProvider {
    public FixedUtcDateTimeProvider(DateTime fixedUtcNow) {
        UtcNow = fixedUtcNow;
    }

    public FixedUtcDateTimeProvider(int year, int month, int day, int hour = 0, int minute = 0, int second = 0, int millisecond = 0) {
        UtcNow = new(year, month, day, hour, minute, second, millisecond, DateTimeKind.Utc);
    }

    public FixedUtcDateTimeProvider(long ticks) {
        UtcNow = new(ticks, DateTimeKind.Utc);
    }

    public DateTime UtcNow { get; }
    public DateTime Now => UtcNow.ToLocalTime();
    public DateTime Today => Now.Date;
}