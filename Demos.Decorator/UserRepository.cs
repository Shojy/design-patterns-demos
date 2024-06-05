namespace Demos.Decorator;

public interface IUserRepository
{
    Task<User?> GetById(int id);
}

// Our base class. This is responsible for handling calls to our database provider
public sealed class UserRepository : IUserRepository
{
    private readonly Database _db;

    public UserRepository(Database db)
    {
        _db = db;
    }

    public Task<User?> GetById(int id)
    {
        return _db.FindById<User>(id);
    }
}