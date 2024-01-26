namespace Glasno.User.Service.Domain.Factory;

public static class UserFactory
{
    public static Entities.User Create()
    {
        return new Entities.User
        {
            Id = 0,
            Username = null,
            Password = null,
            FullName = null,
            AboutMe = null,
            AvatarUrl = null,
            City = null
        };
    }
}