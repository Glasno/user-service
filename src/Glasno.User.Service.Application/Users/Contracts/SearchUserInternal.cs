using MediatR;

namespace Glasno.User.Service.Application.Users.Contracts;

public sealed record SearchUserInternal(
    string Username,
    string Password
) : IRequest<SearchUserResponse>;