namespace System;

public static class RangeExtensions {
    public static CustomRangeEnumerator GetEnumerator(this Range range) => new(range);
}

public ref struct CustomRangeEnumerator {
    private readonly int _end;

    public CustomRangeEnumerator(Range range) {
        if (range.End.IsFromEnd) throw new NotSupportedException("The range end must be provided.");
        Current = range.Start.Value - 1;
        _end = range.End.Value;
    }

    public int Current { get; private set; }

    public bool MoveNext() {
        Current++;
        return Current <= _end;
    }
}
