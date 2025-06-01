using BuberDinner.Domain.Entity;

namespace BuberDinner.Application.common.Interface.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}