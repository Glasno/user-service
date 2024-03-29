using AutoMapper;
using Glasno.User.Service.Application.Commands.Users.Update.Contracts;
using Glasno.User.Service.Infrastructure.Abstractions.Repository;
using MediatR;

namespace Glasno.User.Service.Application.Commands.Users.Update;

public sealed class UpdateUserHandler: IRequestHandler<UpdateUserCommandInternal, UpdateUserResponseInternal>
{
    private readonly IUserRepository _userRepository;
    private readonly Mapper _mapper;

    public UpdateUserHandler(IUserRepository repository, Mapper mapper)
    {
        _userRepository = repository;
        _mapper = mapper;
    }

    public async Task<UpdateUserResponseInternal> Handle(UpdateUserCommandInternal request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Domain.Entities.User>(request);
        
        await _userRepository.Update(user);
        
        return new UpdateUserResponseInternal();
    }
}