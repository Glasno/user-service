using MediatR;

namespace Glasno.User.Service.Application.Users.Contracts;

public sealed record SearchUserResponse (Domain.Entities.User user) 
{
    
}