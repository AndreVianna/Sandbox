namespace System;

public interface IDateTimeProvider {
    DateTime UtcNow { get; }
    DateOnly UtcToday { get; }
    DateTime Now { get; }
    DateOnly Today { get; }
}
