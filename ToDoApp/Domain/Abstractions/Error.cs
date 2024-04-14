namespace Domain.Abstractions;

public sealed record Error(string Code, string? Description = null)
{
    public string? StackTrace { get; init; }
    public Exception? Exception { get; init; }

    public static readonly Error None = new(string.Empty);

    public Error(string code, Exception exception) : this(code, exception.Message)
    {
        StackTrace = exception.StackTrace;
        Exception = exception;
    }
}

