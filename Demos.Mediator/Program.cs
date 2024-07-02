using Demos.Mediator;
using Demos.Mediator.Actions;
using Microsoft.Extensions.DependencyInjection;

// Register Services
var services = new ServiceCollection();
services.AddSingleton<Application>();
services.AddSingleton<IMediator, Mediator>();

// You may wish to add handlers by scanning for types implementing IRequestHandler. We register explicitly below for simplicity
services.AddScoped<SendGreetingHandler>();
services.AddScoped<GetUserDetailsHandler>();

var provider = services.BuildServiceProvider();

// You may also want to scan for these and register them automatically. Again, this is done explicitly below for simplicity.
Mediator.Register<SendGreetingRequest, SendGreetingHandler>();
Mediator.Register<GetUserDetailsRequest, GetUserDetailsHandler>();

// Run out program with dependency injection
await provider.GetService<Application>()!.Run();