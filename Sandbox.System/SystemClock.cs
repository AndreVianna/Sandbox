namespace System;

[ExcludeFromCodeCoverage(Justification = "Testing the system.")]
// ReSharper disable once UnusedType.Global
public sealed class SystemClock : IClock {
    public DateTime UtcNow => DateTime.UtcNow;
    public DateTime Now => DateTime.Now;
}