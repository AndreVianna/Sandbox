namespace System;

public class StaticClock : IClock {
    public StaticClock(DateTime fixDateTime) {
        UtcNow = fixDateTime.ToUniversalTime();
        Now = fixDateTime.ToLocalTime();
    }

    public StaticClock(int year, int month, int day, int hour = 0, int minute = 0, int second = 0, int millisecond = 0, DateTimeKind kind = DateTimeKind.Local)
        : this (new(year, month, day, hour, minute, second, millisecond, kind)) {
    }

    public StaticClock(long ticks, DateTimeKind kind = DateTimeKind.Local)
        : this(new(ticks, kind)) {
    }

    public static StaticClock FromDateTime(DateTime fixedDateTime) => new(fixedDateTime);
    public static StaticClock FromDateTime(int year, int month, int day, int hour = 0, int minute = 0, int second = 0, int millisecond = 0, DateTimeKind kind = DateTimeKind.Local)
        => new(year, month, day, hour, minute, second, millisecond, kind);
    public static StaticClock FromTicks(long ticks, DateTimeKind kind = DateTimeKind.Local) => new(ticks, kind);

    public DateTime UtcNow { get; }
    public DateTime Now { get; }
}