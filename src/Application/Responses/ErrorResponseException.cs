using System.Net;

namespace Application.Responses;

public class ErrorResponseException : Exception
{
    public ErrorResponseException() : base()
    {
    }

    public ErrorResponseException(string? message) : base(message)
    {
    }

    public ErrorResponseException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public required string Error { get; set; }
    public required HttpStatusCode HttpStatusCode { get; set; }
    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
    public List<ErrorDetails>? ErrorDetails { get; set; }
}

public record ErrorDetails(string Field, string Message);
