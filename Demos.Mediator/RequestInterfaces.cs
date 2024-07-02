namespace Demos.Mediator;

// ReSharper disable UnusedTypeParameter

public interface IRequest;

public interface IRequest<TResponse>;

public interface IRequestHandler<in TRequest> where TRequest : IRequest
{
    void Handle(TRequest request);
}

public interface IRequestHandler<in TRequest, out TResponse> where TRequest : IRequest<TResponse>
{
    TResponse Handle(TRequest request);
}
