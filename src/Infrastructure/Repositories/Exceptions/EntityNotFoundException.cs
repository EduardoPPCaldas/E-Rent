namespace Infrastructure.Repositories.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException() : base()
    {
    }

    public EntityNotFoundException(string? message) : base(message)
    {
    }

    public EntityNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
