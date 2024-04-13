namespace Domain.Abstractions;

public class Result<T>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
    public T? Value { get; }
    private Result(bool isSuccess, Error error, T? value = default)
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
        Value = value;
    }

    public static Result<T> Success(T value) => new(true, Error.None, value);
    public static Result<T> Failure(Error error) => new(false, error);
}
