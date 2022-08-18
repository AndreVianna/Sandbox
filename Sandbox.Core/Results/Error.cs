namespace System.Results;

public record Error {
    public Error(string message, params object[] arguments) {
        if (string.IsNullOrWhiteSpace(message)) throw new ArgumentException("Message cannot be null or empty.", nameof(message));
        Message = message;
        Arguments = arguments;
    }

    public string Source { get; init; } = string.Empty;
    public string Message { get; }
    public object[] Arguments { get; }
}
