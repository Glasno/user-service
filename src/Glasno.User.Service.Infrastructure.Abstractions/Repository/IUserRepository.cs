namespace Glasno.User.Service.Infrastructure.Abstractions.Repository;

using Domain.Entities;

public interface IUserRepository
{
    Task<User> Get(long id);
    Task Add(User newUser);
    Task Update(User user);
}