namespace System.Results;

public record ConflictingResult : FailedResult;

public record ConflictingResult<T> : ConflictingResult {
    // ReSharper disable once ConvertToPrimaryConstructor
    public ConflictingResult(T existingValue) {
        this.ExistingValue = existingValue;
    }
    public T ExistingValue { get; }
}
