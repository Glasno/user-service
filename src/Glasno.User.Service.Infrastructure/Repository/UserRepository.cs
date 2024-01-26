using Glasno.User.Service.Application.Exceptions;
using Glasno.User.Service.Infrastructure.Abstractions.Repository;
using Glasno.User.Service.Domain.Entities;
using Glasno.User.Service.Infrastructure.DbConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Glasno.User.Service.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private GlasnoDbContext _db;

    public UserRepository(GlasnoDbContext db)
    {
        _db = db;
    }


    public async Task<Domain.Entities.User> GetUserByUsernameAndPassword(string username, string password)
    {
        var user = await _db.Users
            .SingleOrDefaultAsync(user =>
                user.Username == username &&
                user.Password == password);

        if (user is null) throw new UserNotFoundException($"Пользователь с логином {username} не найден");

        return user;
    }

    public async Task<Domain.Entities.User> GetUserById(Guid id)
    {
        var user = await _db
            .Users
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user is null) throw new UserNotFoundException("Пользователь не найден");

        return user;
    }

    public void CreateUser(Domain.Entities.User newUser)
    {
        _db.Users.Add(newUser);
        _db.SaveChangesAsync();
    }

    public void UpdateUser(Domain.Entities.User user)
    {
        _db.Users.Update(user);
        _db.SaveChangesAsync();
    }
}