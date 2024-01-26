using MediatR;

namespace Glasno.User.Service.Application.Users.Contracts;

public sealed record SearchUserByIdInternal (Guid Id)
    : IRequest;