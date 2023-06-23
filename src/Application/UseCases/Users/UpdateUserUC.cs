using Application.Shared;

namespace Application.UseCases.Users;

[GenerateAutomaticInterface]
public class UpdateUserUC : IUpdateUserUC
{
    public Task Execute(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
