namespace System;

public class FixedLocalDateTimeProvider : IDateTimeProvider {
    public FixedLocalDateTimeProvider(DateTime fixedNow) {
        Now = fixedNow;
    }

    public FixedLocalDateTimeProvider(int year, int month, int day, int hour = 0, int minute = 0, int second = 0, int millisecond = 0) {
        Now = new(year, month, day, hour, minute, second, millisecond, DateTimeKind.Local);
    }

    public FixedLocalDateTimeProvider(long ticks) {
        Now = new(ticks, DateTimeKind.Local);
    }

    public DateTime UtcNow => Now.ToUniversalTime();
    public DateTime Now { get; }
    public DateTime Today => Now.Date;
}