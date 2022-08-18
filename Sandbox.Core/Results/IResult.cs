namespace System.Results;

public interface IResult {
}

public interface IResultWithErrors : IResult {
    public IReadOnlyCollection<Error> Errors { get; }
}

public interface IResult<out T> : IResult {
    T Value { get; }
}
