namespace System;

public class SlidingClock : IClock {
    private DateTime _current;
    private readonly TimeSpan _interval;

    public SlidingClock(DateTime fixedDateTime, TimeSpan interval) {
        _current = fixedDateTime;
        _interval = interval;
    }

    public DateTime UtcNow {
        get {
            var value = _current;
            _current += _interval;
            return value;
        }
    }

    public DateTime Now => UtcNow.ToLocalTime();
}