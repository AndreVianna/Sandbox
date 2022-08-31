namespace System;

public sealed class ParameterizedString : ICloneable, IEquatable<string>, IComparable, IComparable<ParameterizedString?>, IComparable<string> {
    public ParameterizedString(string template, params object?[] arguments) {
        Template = template;
        Arguments = arguments.Length == 1 && arguments[0] is object?[] array ? array : arguments;
        Formatted = StringFormatter.Format(Template, Arguments);
    }

    public string Template { get; }
    public IReadOnlyList<object?> Arguments { get; }
    public string Formatted { get; }

    public static readonly ParameterizedString Empty = new(string.Empty);
    public static ParameterizedString Create(string template, params object?[] arguments) => new(template, arguments);

    public override int GetHashCode() => Formatted.GetHashCode();
    public bool Equals(ParameterizedString other) => Formatted.Equals(other.Formatted);
    public bool Equals(string? other) => Formatted.Equals(other);

    public int CompareTo(ParameterizedString? other) => string.CompareOrdinal(Formatted, other?.Formatted);
    public int CompareTo(string? other) => string.CompareOrdinal(Formatted, other);
    public int CompareTo(object? other) => other is null ? 1 : throw new ArgumentException("Object must be of type String or ParameterizedString.");

    public override string ToString() => Formatted;

    public object Clone() => new ParameterizedString(Template, Arguments);

    public static implicit operator string(ParameterizedString template) => template.Formatted;
}
