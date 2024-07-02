namespace Demos.Mediator;

public interface IMediator
{
    public void Send<TRequest>(TRequest request) where TRequest : IRequest;
    
    public TResponse Send<TRequest, TResponse>(IRequest<TResponse> request) where TRequest : IRequest<TResponse>;
}

public class Mediator : IMediator
{
    private static readonly Dictionary<Type, Type> Map = new();
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static void Register<TRequest, THandler>()
    {
        Map.TryAdd(typeof(TRequest), typeof(THandler));
    }

    public void Send<TRequest>(TRequest request) where TRequest : IRequest
    {
        if (Map.TryGetValue(typeof(TRequest), out var handlerType))
        {
            var handler = (IRequestHandler<TRequest>)_serviceProvider.GetService(handlerType)!;
            handler.Handle(request);
            return;
        }
        
        // Throw an error if we don't have a registered handler for the request
        throw new NotSupportedException();
    }

    public TResponse Send<TRequest, TResponse>(IRequest<TResponse> request) where TRequest : IRequest<TResponse>
    {
        if (Map.TryGetValue(request.GetType(), out var handlerType))
        {
            var handler = (IRequestHandler<TRequest, TResponse>)_serviceProvider.GetService(handlerType)!;
            return handler.Handle((TRequest)request);
        }

        // Throw an error if we don't have a registered handler for the request
        throw new NotSupportedException();
    }
}
