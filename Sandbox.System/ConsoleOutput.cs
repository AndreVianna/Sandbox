namespace System;

[ExcludeFromCodeCoverage(Justification = "Testing the system.")]
public sealed class ConsoleOutput : IOutput {
    public void Write(ulong value) => Console.Write(value);
    public void Write(uint value) => Console.Write(value);
    public void Write(StringBuilder? value) => Console.Write(value);
    public void Write(string format, params object?[] arg) => Console.Write(format, arg);
    public void Write(string format, object? arg0, object? arg1, object? arg2) => Console.Write(format, arg0, arg1, arg2);
    public void Write(string format, object? arg0, object? arg1) => Console.Write(format, arg0, arg1);
    public void Write(string format, object? arg0) => Console.Write(format, arg0);
    public void Write(string? value) => Console.Write(value);
    public void Write(object? value) => Console.Write(value);
    public void Write(long value) => Console.Write(value);
    public void Write(int value) => Console.Write(value);
    public void Write(double value) => Console.Write(value);
    public void Write(decimal value) => Console.Write(value);
    public void Write(char[] buffer, int index, int count) => Console.Write(buffer, index, count);
    public void Write(char[]? buffer) => Console.Write(buffer);
    public void Write(char value) => Console.Write(value);
    public void Write(bool value) => Console.Write(value);
    public void Write(float value) => Console.Write(value);

    public void WriteLine(ulong value) => Console.WriteLine(value);
    public void WriteLine(uint value) => Console.WriteLine(value);
    public void WriteLine(StringBuilder? value) => Console.WriteLine(value);
    public void WriteLine(string format, params object?[] arg) => Console.WriteLine(format, arg);
    public void WriteLine(string format, object? arg0) => Console.WriteLine(format, arg0);
    public void WriteLine(string format, object? arg0, object? arg1) => Console.WriteLine(format, arg0, arg1);
    public void WriteLine(string format, object? arg0, object? arg1, object? arg2) => Console.WriteLine(format, arg0, arg1, arg2);
    public void WriteLine(string? value) => Console.WriteLine(value);
    public void WriteLine(float value) => Console.WriteLine(value);
    public void WriteLine(object? value) => Console.WriteLine(value);
    public void WriteLine(bool value) => Console.WriteLine(value);
    public void WriteLine(char value) => Console.WriteLine(value);
    public void WriteLine(char[]? buffer) => Console.WriteLine(buffer);
    public void WriteLine() => Console.WriteLine();
    public void WriteLine(decimal value) => Console.WriteLine(value);
    public void WriteLine(double value) => Console.WriteLine(value);
    public void WriteLine(int value) => Console.WriteLine(value);
    public void WriteLine(long value) => Console.WriteLine(value);
    public void WriteLine(char[] buffer, int index, int count) => Console.WriteLine(buffer, index, count);
}
