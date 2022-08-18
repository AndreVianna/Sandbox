namespace System.Results;

public interface IResult {
    public IReadOnlyCollection<Error> Errors { get; }
}

public interface IResult<out T> : IResult {
    T Value { get; }
}
