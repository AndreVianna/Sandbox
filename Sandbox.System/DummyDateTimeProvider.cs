namespace System;

public abstract class DummyDateTimeProvider : IDateTimeProvider {
    public virtual DateTime UtcNow => throw new NotImplementedException();
    public virtual DateTime Now => throw new NotImplementedException();
    public virtual DateTime Today => throw new NotImplementedException();
}