using Demos.Mediator.Actions;

namespace Demos.Mediator;

public class Application
{
    private readonly IMediator _mediator;

    public Application(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public Task Run()
    {
        var user = _mediator.Send<GetUserDetailsRequest, UserDetails>(new GetUserDetailsRequest(1));

        _mediator.Send(new SendGreetingRequest($"{user.Name} [id:{user.Id}]"));
        
        return Task.CompletedTask;
    }
}