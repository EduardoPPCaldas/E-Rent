using System.Net;

namespace Application.Responses;

public class ErrorResponse
{
    
    public required string Error { get; set; }
    public required HttpStatusCode HttpStatusCode { get; set; }
    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
    public List<ErrorDetails>? ErrorDetails { get; set; }
}
