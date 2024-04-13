namespace Domain.Abstractions;

public sealed record Error(string Code, string? Description = null)
{
    public static readonly Error None = new(string.Empty);
}

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
    private Result(bool isSuccess, Error error)
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

    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);
}
