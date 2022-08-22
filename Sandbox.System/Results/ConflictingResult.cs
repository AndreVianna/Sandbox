namespace System.Results;

public record ConflictingResult : FailedResult;

public record ConflictingResult<T> : ConflictingResult {
    // ReSharper disable once ConvertToPrimaryConstructor
    public ConflictingResult(T conflictSource) {
        ConflictSource = conflictSource;
    }
    public T ConflictSource { get; }
}
