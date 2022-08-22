namespace System.Results;

public record SuccessfulResult : Result;

public record SuccessfulResult<TValue> : SuccessfulResult, IResult<TValue> {
    // ReSharper disable once ConvertToPrimaryConstructor
    public SuccessfulResult(TValue value) {
        Value = value;
    }

    public TValue Value { get; }
}
