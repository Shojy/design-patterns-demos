namespace Demos.Decorator;

public record User(int Id, string Name);

public class Database
{
    public async Task<User?> FindById<T>(int id)
    {
        await Task.Delay(750);
        return new User(id, $"User {id}");
    }
}