using AutoMapper;
using FluentResults;
using Glasno.User.Service.Application.Commands.Users.Create.Contracts;
using Glasno.User.Service.Application.Queries.Users.Search.Contracts;
using Glasno.User.Service.Presentation.Controllers.Users.Contracts;
using Glasno.User.Service.Presentation.Dto;
using Glasno.User.Service.Presentation.Dto.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Glasno.User.Service.Presentation.Controllers.Users;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly Mapper _mapper;

    public UserController(IMediator mediator, Mapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpGet("/{id}")]
    public async Task<Result<UserInformationDto>> GetUserById(long id)
    {
        var internalQuery =  new GetUserQueryInternal(id);
        
        var internalResponse = await _mediator.Send(internalQuery);

        var response = _mapper.Map<UserInformationDto>(internalResponse);
        
        return response;
    }

    [HttpPost]
    public async Task<Result> CreateUser([FromBody] CreateUserCommandDto createUserCommandDto)
    {
        var internalQuery = _mapper.Map<CreateUserCommandInternal>(createUserCommandDto);
        
        var internalResponse = await _mediator.Send(internalQuery);
        
        return Result.Ok();
    }

    [HttpPut]
    public async Task<Result> UpdateUser([FromBody] UpdateUserCommandDto updateUserCommandDto)
    {
        var internalQuery = _mapper.Map<UpdateUserCommandDto>(updateUserCommandDto);
        
        var internalResponse = await _mediator.Send(internalQuery);
        
        return Result.Ok();
    }
}