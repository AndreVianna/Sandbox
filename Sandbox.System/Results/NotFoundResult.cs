namespace System.Results;

public record NotFoundResult : FailedResult;

public record NotFoundResult<TValue> : FailedResult<TValue>;