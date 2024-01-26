using AutoMapper;
using Glasno.User.Service.Application.Users.Contracts;
using Glasno.User.Service.Infrastructure.Abstractions.Repository;
using MediatR;

namespace Glasno.User.Service.Application.Users;

internal sealed class SearchUsersHandler : IRequestHandler<SearchUserInternal, SearchUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly Mapper _mapper;

    public SearchUsersHandler(IUserRepository userRepository, Mapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<SearchUserResponse> Handle(SearchUserInternal request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByUsernameAndPassword(request.Username, request.Password);


        return new SearchUserResponse(user);
    }
    public async Task<SearchUserResponse> Handle(SearchUserByIdInternal request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.Id);


        return new SearchUserResponse(user);
    }
}