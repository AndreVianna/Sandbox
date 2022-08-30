namespace System.Validation;

public record ValidationError {
    public ValidationError(string message) {
        if (string.IsNullOrWhiteSpace(message)) throw new ArgumentException("Message cannot be null or empty.", nameof(message));
        Message = new(message);
        Code = message;
    }

    public ValidationError(string format, params object?[] arguments) {
        if (string.IsNullOrWhiteSpace(format)) throw new ArgumentException("Message format cannot be null or empty.", nameof(format));
        Message = new(format, arguments);
        Code = format;
    }

    public string Code { get; init; }
    public string Source { get; init; } = string.Empty;
    public TemplatedString Message { get; }
}
