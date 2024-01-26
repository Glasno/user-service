namespace Glasno.User.Service.Domain.Entities;

public sealed class User
{
    public User(Guid id, string username, string password, string fullName, string aboutMe, string avatarUrl, string city,
        IList<string> specializations, IList<string> services)
    {
        Id = id;
        Username = username;
        Password = password;
        FullName = fullName;
        AboutMe = aboutMe;
        AvatarUrl = avatarUrl;
        City = city;
        Specializations = specializations;
        Services = services;
    }


    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public string FullName { get; set; }

    public string AboutMe { get; set; }

    public string AvatarUrl { get; set; }

    public string City { get; set; }

    public IList<string> Specializations { get; set; }
    public IList<string> Services { get; set; }
}