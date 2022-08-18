namespace System;

[ExcludeFromCodeCoverage(Justification = "Testing the system.")]
public sealed class DefaultDateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow => DateTime.UtcNow;
    public DateTime Now => DateTime.Now;
    public DateTime Today => DateTime.Today;
}