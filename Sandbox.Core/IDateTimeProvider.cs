// ReSharper disable UnusedMemberInSuper.Global
namespace System;

public interface IDateTimeProvider {
    DateTime UtcNow { get; }
    DateTime Now { get; }
    DateTime Today { get; }
}
