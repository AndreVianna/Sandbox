namespace System.Results;

public record ConflictingResult : FailedResult;

public record ConflictingResult<T> : ConflictingResult {
    public ConflictingResult(T value) {
        this.Value = value;
    }
    public T Value { get; }
}
