using Demos.Mediator.Actions;

namespace Demos.Mediator;

public class Application
{
    private readonly IMediator _mediator;

    // Inject our dependency on the mediator object - this is the only direct dependency we should need here.
    public Application(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public Task Run()
    {
        // Send a request that needs a response via the mediator
        var user = _mediator.Send<GetUserDetailsRequest, UserDetails>(new GetUserDetailsRequest(1));

        // Send a request via the mediator that doesn't require a response
        _mediator.Send(new SendGreetingRequest($"{user.Name} [id:{user.Id}]"));
        
        return Task.CompletedTask;
    }
}