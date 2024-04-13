namespace Domain.Abstractions;

public class Result
{
    public bool IsSuccess { get; }
    public Error Error { get; }
    protected Result(bool isSuccess, Error error)
    {
        // Checks if a success result is being created with an error or
        // if a failure result is being created without an error
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Failure(Error error) => new(false, error);
}

public class ResultOf<T> : Result
{
    public T? Value { get; }

    private ResultOf(bool isSuccess, Error error, T? value = default)
        : base(isSuccess, error)
    {
        Value = value;
    }

    public static ResultOf<T> Success(T value) => new (true,Error.None,value);
	public static new ResultOf<T> Failure(Error error) => new(false, error);
}

public class ResultOfCollection<T> : Result
{
    public IEnumerable<T>? Values { get; }

    private ResultOfCollection(bool isSuccess, Error error,  IEnumerable<T>? values = null)
        : base(isSuccess, error) 
    {
        Values = values ?? [];
    }

    public static ResultOfCollection<T> Success(IEnumerable<T> values) => new (true,Error.None,values);
	public static new ResultOfCollection<T> Failure(Error error) => new(false, error);

}
