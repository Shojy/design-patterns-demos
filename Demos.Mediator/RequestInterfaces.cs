namespace Demos.Mediator;

public interface IRequest;

// ReSharper disable once UnusedTypeParameter
public interface IRequest<TResponse>;

public interface IRequestHandler<in TRequest> where TRequest : IRequest
{
    void Handle(TRequest request);
}

public interface IRequestHandler<in TRequest, out TResponse> where TRequest : IRequest<TResponse>
{
    TResponse Handle(TRequest request);
}
