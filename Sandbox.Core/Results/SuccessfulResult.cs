namespace System.Results;

public record SuccessfulResult : Result;

public record SuccessfulResult<T> : SuccessfulResult {
    // ReSharper disable once ConvertToPrimaryConstructor
    public SuccessfulResult(T value) {
        this.Value = value;
    }

    public T Value { get; }
}
