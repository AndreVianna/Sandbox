namespace System.Results;

public record SuccessResult : IResult;

public record SuccessResult<T>(T Value) : SuccessResult, IResult<T>;
