namespace Application.Responses.Users;

public class CreateUserResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}
