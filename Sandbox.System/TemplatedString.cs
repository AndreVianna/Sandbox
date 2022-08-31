namespace System;

public readonly record struct TemplatedString : IEquatable<string>, IComparable, IComparable<TemplatedString?>, IComparable<string> {
    public TemplatedString(string template, params object?[] arguments) {
        Template = template;
        Arguments = arguments;
    }

    public string Template { get; }
    public IReadOnlyList<object?> Arguments { get; }
    public string Formatted => StringFormatter.Format(Template, Arguments);

    public override int GetHashCode() => Formatted.GetHashCode();
    public bool Equals(TemplatedString other) => Formatted.Equals(other.Formatted);
    public bool Equals(string? other) => Formatted.Equals(other);

    public int CompareTo(TemplatedString? other) => string.CompareOrdinal(Formatted, other?.Formatted);
    public int CompareTo(string? other) => string.CompareOrdinal(Formatted, other);
    public int CompareTo(object? other) => other is null ? 1 : throw new ArgumentException("Object must be of type String or TemplatedString.");

    public override string ToString() => Formatted;

    public static implicit operator string(TemplatedString template) => template.Formatted;
}
