using BuberDinner.Application.common.Interface.Persistence;
using BuberDinner.Domain.Entity;

namespace BuberDinner.infrastructure.persistence;

public class UserRepository : IUserRepository
{

    private static readonly List<User> _users = new();
    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.FirstOrDefault(user => user.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }
}