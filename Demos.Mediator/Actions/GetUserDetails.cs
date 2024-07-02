namespace Demos.Mediator.Actions;

public record UserDetails(int Id, string Name);

public record GetUserDetailsRequest(int Id) : IRequest<UserDetails>;

public class GetUserDetailsHandler : IRequestHandler<GetUserDetailsRequest, UserDetails>
{
    public UserDetails Handle(GetUserDetailsRequest request)
    {
        // Fake getting some user details - the exact implementation isn't relevant
        var user = new UserDetails(request.Id, "John Smith");
        return user;
    }
}