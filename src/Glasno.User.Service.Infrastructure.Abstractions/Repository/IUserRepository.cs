namespace Glasno.User.Service.Infrastructure.Abstractions.Repository;

using Domain.Entities;

public interface IUserRepository
{
    Task<User> GetUser(string username, string password);
    Task<User> GetUser(long id);
    Task CreateUser(User newUser);
    Task UpdateUser(User user);
}