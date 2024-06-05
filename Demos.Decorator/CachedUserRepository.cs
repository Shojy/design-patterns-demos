namespace Demos.Decorator;

// Our decorating class. This is responsible for adding caching functionality to our base class
public class CachedUserRepository : IUserRepository
{
    private readonly UserRepository _repository;
    
    // This isn't thread-safe. Use a real cache if you do something like this :)
    private static readonly Dictionary<string, User?> Cache = [];

    public CachedUserRepository(UserRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<User?> GetById(int id)
    {
        if (Cache.TryGetValue(Key(id), out var u))
        {
            return u;
        }

        // Pass the call to the class we're decorating
        var user = await _repository.GetById(id);

        Cache.Add(Key(id), user);

        return user;
    }

    private static string Key(int id) => $"user:{id}";
}