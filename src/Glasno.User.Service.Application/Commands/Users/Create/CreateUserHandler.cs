using AutoMapper;
using Glasno.User.Service.Application.Commands.Users.Create.Contracts;
using Glasno.User.Service.Infrastructure.Abstractions.Repository;
using MediatR;

namespace Glasno.User.Service.Application.Commands.Users.Create;

internal sealed class CreateUserHandler : IRequestHandler<CreateUserCommandInternal, CreateUserResponseInternal>
{
    private readonly IUserRepository _userRepository;
    private readonly Mapper _mapper;

    public CreateUserHandler(IUserRepository userRepository, Mapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    } 
    

    public async Task<CreateUserResponseInternal> Handle(CreateUserCommandInternal request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Domain.Entities.User>(request);
        await _userRepository.Add(user);

        return new CreateUserResponseInternal();
    }
}