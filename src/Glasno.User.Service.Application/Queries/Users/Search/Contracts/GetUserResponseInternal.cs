using MediatR;

namespace Glasno.User.Service.Application.Queries.Users.Search.Contracts;


public sealed record GetUserResponseInternal (Domain.Entities.User user)
{
    
}