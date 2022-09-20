namespace System;

public class VaryingClock : IClock {
    private DateTime _current;
    private readonly Func<TimeSpan> _getIncrement;

    public VaryingClock(DateTime fixedDateTime, Func<TimeSpan> getIncrement) {
        _current = fixedDateTime;
        _getIncrement = getIncrement;
    }

    public DateTime UtcNow {
        get {
            var value = _current;
            _current += _getIncrement();
            return value;
        }
    }

    public DateTime Now => UtcNow.ToLocalTime();
}