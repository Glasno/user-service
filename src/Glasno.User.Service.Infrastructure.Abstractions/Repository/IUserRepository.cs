namespace Glasno.User.Service.Infrastructure.Abstractions.Repository;

using Domain.Entities;

public interface IUserRepository
{
    Task<User> GetUserByUsernameAndPassword(string username, string password);
    Task<User> GetUserById(Guid id);
    void CreateUser(User newUser);
    void UpdateUser(User user);
}