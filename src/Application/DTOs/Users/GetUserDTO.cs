namespace Application.DTOs.Users;

public class GetUserDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}
