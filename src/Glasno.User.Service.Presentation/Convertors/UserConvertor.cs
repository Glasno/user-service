using AutoMapper;
using Glasno.User.Service.Application.Users.Contracts;
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

    public SearchUserByIdInternal ToInternal(Guid id)
    {
        return new SearchUserByIdInternal(id);
    }


    public static UserInformationDto ToFullInformationDTO(Domain.Entities.User user)
    {
        return new UserInformationDto(
            user.Id,
            user.Username,
            user.FullName,
            user.AboutMe,
            user.AvatarUrl,
            user.City,
            user.Specializations);
    }

    public static Domain.Entities.User FromCreateUserDTO(CreateOrUpdateUserDto createOrUpdateUserDto)
    {
        return new Domain.Entities.User(
            Guid.NewGuid(),
            createOrUpdateUserDto.Username,
            createOrUpdateUserDto.Password,
            createOrUpdateUserDto.FullName,
            createOrUpdateUserDto.AboutMe,
            createOrUpdateUserDto.AvatarUrl,
            createOrUpdateUserDto.City,
            createOrUpdateUserDto.Specializations, createOrUpdateUserDto.Services);
    }
}