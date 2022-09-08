namespace System;

public class FixedClock : IClock {
    public FixedClock(DateTime fixedDateTime) {
        UtcNow = fixedDateTime.ToUniversalTime();
        Now = fixedDateTime.ToLocalTime();
    }

    public FixedClock(int year, int month, int day, int hour = 0, int minute = 0, int second = 0, int millisecond = 0, DateTimeKind kind = DateTimeKind.Local)
        : this (new(year, month, day, hour, minute, second, millisecond, kind)) {
    }

    public FixedClock(long ticks, DateTimeKind kind = DateTimeKind.Local)
        : this(new(ticks, kind)) {
    }

    public static FixedClock FromDateTime(DateTime fixedDateTime) => new(fixedDateTime);
    public static FixedClock FromDateTime(int year, int month, int day, int hour = 0, int minute = 0, int second = 0, int millisecond = 0, DateTimeKind kind = DateTimeKind.Local)
        => new(year, month, day, hour, minute, second, millisecond, kind);
    public static FixedClock FromTicks(long ticks, DateTimeKind kind = DateTimeKind.Local) => new(ticks, kind);

    public DateTime UtcNow { get; }
    public DateTime Now { get; }
}