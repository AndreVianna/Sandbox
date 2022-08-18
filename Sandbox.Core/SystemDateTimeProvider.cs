namespace System;

public class SystemDateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow => DateTime.UtcNow;
    public DateOnly UtcToday => DateOnly.FromDateTime(DateTime.UtcNow);
    public DateTime Now => DateTime.Now;
    public DateOnly Today => DateOnly.FromDateTime(DateTime.Now);
}