using System.Diagnostics;
using Demos.Decorator;

Console.WriteLine("Starting DB calls \n ------------------");

// Usually you'd do this bit through dependency injection, but it's just being explicit below to keep things simple
IUserRepository userRepo = new UserRepository(new Database());

await RunDbCalls(userRepo);

Console.WriteLine("-----------------");

// Now we decorate the UserRepository with a caching layer. 
// There's no need to change the interface, we simply sub out the original class with the decorator class, and consumers
// will automatically work in exactly the same way.
userRepo = new CachedUserRepository(new UserRepository(new Database()));

Console.WriteLine("Starting Cached calls \n ------------------");

await RunDbCalls(userRepo);

Console.WriteLine("-----------------");
return;


// The below function will run the same check of 20 randomised calls to the provided repository. As the consumer, it
// doesn't need to know about the actual implementation, and will happily use either base or decorated versions.
async Task RunDbCalls(IUserRepository userRepository)
{
    var stopwatch = new Stopwatch();
    stopwatch.Start();
    
    for (var i = 0; i < 20; ++i)
    {
        var id = Random.Shared.Next(1, 6);

        var user = await userRepository.GetById(id);
    
        Console.WriteLine(user);
    }

    stopwatch.Stop();
    Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds}ms");
}
