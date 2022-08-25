namespace System.Results;

public record SuccessfulResult : IResult;

public record SuccessfulResultFor<TValue> : IResult<TValue> {
    // ReSharper disable once ConvertToPrimaryConstructor
    public SuccessfulResultFor(TValue value) {
        Value = value;
    }

    public TValue Value { get; }
}