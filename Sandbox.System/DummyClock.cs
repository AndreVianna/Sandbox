namespace System;

public abstract class DummyClock : IClock {
    public virtual DateTime UtcNow => throw new NotImplementedException();
    public virtual DateTime Now => throw new NotImplementedException();
}