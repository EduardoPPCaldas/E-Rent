namespace Api.Endpoints;

public interface IEndpointGroup
{
    void Register(IEndpointRouteBuilder app);
}
