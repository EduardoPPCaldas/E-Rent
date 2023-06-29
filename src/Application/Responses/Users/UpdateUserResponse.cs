namespace Application.Responses.Users;

public class UpdateUserResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}
