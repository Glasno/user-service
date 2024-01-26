using AutoMapper;
using Glasno.User.Service.Application.Queries.Users.Search.Contracts;
using Glasno.User.Service.Presentation.Dto;
using Glasno.User.Service.Presentation.Dto.Requests;

namespace Glasno.User.Service.Presentation.Convertors;

public class UserConvertor
{
    private Mapper _mapper;

    public UserConvertor(Mapper mapper)
    {
        _mapper = mapper;
    }

    public GetUserByIdQueryInternal ToInternal(Guid id)
    {
        return new GetUserByIdQueryInternal(id);
    }


    public UserInformationDto ToFullInformationDTO(GetUserResponseInternal responseInternal)
    {
        return _mapper.Map<UserInformationDto>(responseInternal.user);
    }

    public static Domain.Entities.User FromCreateUserDTO(CreateUserCommandDto createUserCommandDto)
    {
        return new Domain.Entities.User(
            Guid.NewGuid(),
            createUserCommandDto.Username,
            createUserCommandDto.Password,
            createUserCommandDto.FullName,
            createUserCommandDto.AboutMe,
            createUserCommandDto.AvatarUrl,
            createUserCommandDto.City,
            createUserCommandDto.Specializations, createUserCommandDto.Services);
    }
}