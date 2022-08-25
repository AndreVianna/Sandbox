namespace System.Results;

public interface IResult { }

public interface IResult<out TValue> {
    TValue Value { get; }
}