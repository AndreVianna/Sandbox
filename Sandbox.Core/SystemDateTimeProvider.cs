namespace System;

[ExcludeFromCodeCoverage(Justification = "Testing the system.")]
public class SystemDateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow => DateTime.UtcNow;
    public DateTime Now => DateTime.Now;
    public DateTime Today => DateTime.Today;
}