namespace System;

public sealed class Nothing {
    static Nothing() {
    }

    private Nothing() {
    }

    public static Nothing Instance { get; } = new();

    public override string ToString() => "[Nothing]";
}