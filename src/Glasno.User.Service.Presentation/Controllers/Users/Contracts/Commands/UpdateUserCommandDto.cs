namespace Glasno.User.Service.Presentation.Controllers.Users.Contracts;

public sealed record UpdateUserCommandDto(
    string Username,
    string Password,
    string FullName,
    string AboutMe,
    string AvatarUrl,
    string City
);