// ReSharper disable UnusedMemberInSuper.Global
namespace System;

public interface IClock {
    DateTime UtcNow { get; }
    DateTime Now { get; }
}
