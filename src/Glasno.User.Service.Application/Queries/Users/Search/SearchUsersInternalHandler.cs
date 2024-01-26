using AutoMapper;
using Glasno.User.Service.Application.Commands.Users.Create.Contracts;
using Glasno.User.Service.Infrastructure.Abstractions.Repository;
using MediatR;
using GetUserQueryInternal = Glasno.User.Service.Application.Queries.Users.Search.Contracts.GetUserQueryInternal;
using GetUserResponseInternal = Glasno.User.Service.Application.Queries.Users.Search.Contracts.GetUserResponseInternal;

namespace Glasno.User.Service.Application.Queries.Users.Search;

internal sealed class SearchUsersInternalHandler : IRequestHandler<GetUserQueryInternal, GetUserResponseInternal>
{
    private readonly IUserRepository _userRepository;
    private readonly Mapper _mapper;

    public SearchUsersInternalHandler(IUserRepository userRepository, Mapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }


    public async Task<GetUserResponseInternal> Handle(GetUserQueryInternal request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUser(request.Id);

        return new GetUserResponseInternal(user);
    }
}