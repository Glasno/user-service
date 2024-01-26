using FluentResults;
using Glasno.User.Service.Presentation.Convertors;
using Glasno.User.Service.Presentation.Dto;
using Glasno.User.Service.Presentation.Dto.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Glasno.User.Service.Presentation.Controllers;

[ApiController]
[Route("api/user")]
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
    public IResult CreateUser([FromBody] CreateUserCommandDto createUserCommandDto)
    {
        var newUser = UserConvertor.FromCreateUserDTO(createUserCommandDto);
        _userService.CreateUser(newUser);

        return Results.Ok();
    }

    [HttpPut]
    public IResult UpdateUser([FromBody] CreateUserCommandDto updateUserCommandDto)
    {
        var newUser = UserConvertor.FromCreateUserDTO(updateUserCommandDto);
        _userService.UpdateUser(newUser);
        return Results.Ok();
    }
}