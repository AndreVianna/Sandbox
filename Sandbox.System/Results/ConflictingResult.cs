namespace System.Results;

public record ConflictingResult : FailedResult {
    // ReSharper disable once ConvertToPrimaryConstructor
    public ConflictingResult(string? reason = null) {
        Reason = reason ?? string.Empty;
    }

    public string? Reason { get; }
}

public record ConflictingResult<TValue> : FailedResult<TValue> {
    // ReSharper disable once ConvertToPrimaryConstructor
    public ConflictingResult(string? reason = null) {
        Reason = reason ?? string.Empty;
    }

    public string? Reason { get; }
}