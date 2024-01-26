using FluentResults;
using Glasno.User.Service.Domain.Services;
using Glasno.User.Service.Presentation.Convertors;
using Glasno.User.Service.Presentation.Dto;
using Glasno.User.Service.Presentation.Dto.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Glasno.User.Service.Presentation.Controllers;

[ApiController]
[Route("api/user/")]
public class UserController
{
    private readonly IMediator _mediator;
    private readonly UserConvertor _convertor;

    public UserController(IMediator mediator, UserConvertor convertor)
    {
        _mediator = mediator;
        _convertor = convertor;
    }

    [HttpGet("/{id}")]
    public async Task<Result<UserInformationDto>> GetUserById(Guid id)
    {
        var internalQuery = _convertor.ToInternal(id);
        
        var internalResponse = await _mediator.Send(internalQuery);

        var response = _convertor.ToFullInformationDTO(internalResponse);
        
        return response;
    }

    [HttpPost]
    public IResult CreateUser([FromBody] CreateOrUpdateUserDto createOrUpdateUserDto)
    {
        var newUser = UserConvertor.FromCreateUserDTO(createOrUpdateUserDto);
        _userService.CreateUser(newUser);

        return Results.Ok();
    }

    [HttpPut]
    public IResult UpdateUser([FromBody] CreateOrUpdateUserDto updateUserDto)
    {
        var newUser = UserConvertor.FromCreateUserDTO(updateUserDto);
        _userService.UpdateUser(newUser);
        return Results.Ok();
    }
}