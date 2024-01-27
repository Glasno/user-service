namespace Glasno.User.Service.Presentation.Dto.Requests;

public sealed record CreateUserCommandDto(
    string Username,
    string Password,
    string FullName,
    string AboutMe,
    string AvatarUrl,
    string City
);