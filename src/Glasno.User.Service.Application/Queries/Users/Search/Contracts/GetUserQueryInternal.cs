using MediatR;

namespace Glasno.User.Service.Application.Queries.Users.Search.Contracts;

public sealed record GetUserQueryInternal(
    long Id
) : IRequest<GetUserResponseInternal>;