# Mediator

Mediator is a design pattern used to reduce the dependencies between objects, providing a central dependency on a single Mediator object that passes requests along to relevant handlers. Calling objects are not required to know about what is handling their request - simply that it will be handled.

In our example code, we have 2 handlers that represent different services in our system. For each one, we include a request object that is exposed to calling services:
`GetUserDetailsHandler` contains the logic for fetching a particular user based on a given Id, provided as part of the `GetUserDetailsRequest`. The request will then return a `UserDetails` instance, containing the details for the given user. The `SendGreetingHandler` contains logic for greeting someone, and has no response to provide once it does this.

Our calling application only needs to know about the request, and the response - giving no dependency on functional types, except for the mediator itself.

Additionally, because the handler is reduced to a single behaviour, it becomes easier to test as needed. If it relies on external services, such as a database, these can be injected directly to the handler as required. This also helps to reduce the number of instansiated objects for a larger service that may not be required for all functions, helping to limit to a single responsibility.

## Benefits

- Vastly reduces coupling between dependent classes
- Easier to reuse individual components and functionality
- Easy to change a handler for a request without needing to update direct dependencies
- Changes to functionality becomes isolated to the specific handler

## Implementing

There are several ways of implementing a mediator itself. It may expose methods that correlate to connected functions, or (as provided in the sample), style itself after a request-response message broker. In our implementation, we use the `IMediator` interface, that is the dependency provided to callers, and the `Mediator` concrete class that implements it.

We also make use of the `IRequest` and `IRequestHandler` interfaces, allowing us some abstraction from concrete handler types. There are generic overloads of each for requests that want to provide a response.
