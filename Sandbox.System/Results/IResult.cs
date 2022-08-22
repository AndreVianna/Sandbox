namespace System.Results;

public interface IResult<out TValue> {
    TValue Value { get; }
}

public interface IResult { }
