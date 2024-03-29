namespace Glasno.User.Service.Domain.Entities;

public sealed class User
{
    public  long Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }

    public required string FullName { get; set; }

    public string? AboutMe { get; set; }

    public required string AvatarUrl { get; set; }

    public string? City { get; set; }
    
}