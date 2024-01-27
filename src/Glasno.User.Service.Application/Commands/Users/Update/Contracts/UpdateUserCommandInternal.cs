using MediatR;

namespace Glasno.User.Service.Application.Commands.Users.Update.Contracts;

public record UpdateUserCommandInternal(
    string Username,
    string Password,
    string FullName,
    string AboutMe,
    string AvatarUrl,
    string City
) : IRequest<UpdateUserResponseInternal>;