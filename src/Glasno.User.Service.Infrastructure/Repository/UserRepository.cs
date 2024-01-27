using Glasno.User.Service.Infrastructure.Abstractions.Repository;
using Glasno.User.Service.Domain.Entities;
using Glasno.User.Service.Domain.Exceptions;
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


    public async Task<Domain.Entities.User> Get(long id)
    {
        var user = await _db
            .Users
            .SingleOrDefaultAsync(u => u.Id == id);

        if (user is null) throw new UserNotFoundException("Пользователь не найден");

        return user;
    }

    public Task Add(Domain.Entities.User newUser)
    {
        _db.Users.Add(newUser);
        return _db.SaveChangesAsync();
    }

    public Task Update(Domain.Entities.User user)
    {
        _db.Users.Update(user);
        return _db.SaveChangesAsync();
    }
}