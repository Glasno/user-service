using MediatR;

namespace Glasno.User.Service.Application.Commands.Users.Create.Contracts;

public sealed record CreateUserCommandInternal(
    string Username,
    string Password,
    string FullName,
    string AboutMe,
    string AvatarUrl,
    string City,
    IList<string> Specializations,
    IList<string> Services
): IRequest<CreateUserResponseInternal>;