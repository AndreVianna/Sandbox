namespace System;

public class FixedDateTimeProvider : IDateTimeProvider {
    public FixedDateTimeProvider(DateTime fixedDateTime) {
        UtcNow = fixedDateTime.ToUniversalTime();
        Now = fixedDateTime.ToLocalTime();
    }

    public FixedDateTimeProvider(int year, int month, int day, int hour = 0, int minute = 0, int second = 0, int millisecond = 0, DateTimeKind kind = DateTimeKind.Local)
        : this (new(year, month, day, hour, minute, second, millisecond, kind)) {
    }

    public FixedDateTimeProvider(long ticks, DateTimeKind kind = DateTimeKind.Local)
        : this(new(ticks, kind)) {
    }

    public static FixedDateTimeProvider FromDateTime(DateTime fixedDateTime) => new(fixedDateTime);
    public static FixedDateTimeProvider FromDateTime(int year, int month, int day, int hour = 0, int minute = 0, int second = 0, int millisecond = 0, DateTimeKind kind = DateTimeKind.Local)
        => new(year, month, day, hour, minute, second, millisecond, kind);
    public static FixedDateTimeProvider FromTicks(long ticks, DateTimeKind kind = DateTimeKind.Local) => new(ticks, kind);

    public DateTime UtcNow { get; }
    public DateTime Now { get; }
    public DateTime Today => Now.Date;
}