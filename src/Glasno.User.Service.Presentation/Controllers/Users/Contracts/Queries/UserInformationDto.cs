namespace Glasno.User.Service.Presentation.Dto;

public sealed record UserInformationDto(
    Guid id,
    string username,
    string fullName,
    string aboutMe,
    string avatarUrl,
    string city,
    IList<string> specializations
);