namespace Demos.Mediator.Actions;

public record SendGreetingRequest(string Name) : IRequest;

public class SendGreetingHandler : IRequestHandler<SendGreetingRequest>
{
    public void Handle(SendGreetingRequest request)
    {
        // We're outputting to console for simplicity here. In a real system, we might send this via a communication
        // channel such as email or SMS
        Console.WriteLine($"Hello, {request.Name}");
    }
}