using AgroTemp.Application.Commands.Users.AddUser;
using AgroTemp.Application.Commands.Users.RemoveUser;
using AgroTemp.Application.Commands.Users.UpdateUser;
using AgroTemp.Application.Dtos;
using AgroTemp.Application.Queries.Users.GetUserById;
using AgroTemp.Application.Queries.Users.GetUserByLoginAndPassword;
using AgroTemp.Application.Queries.Users.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace AgroTemp.Presentation.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : Controller
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerOperation("Get users.")]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get()
    {
        var results = await _mediator.Send(new GetUsersQuery());

        return Ok(results);
    }

    [HttpGet("{id}")]
    [SwaggerOperation("Get user by id.")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(id));

        return Ok(result);
    }

    [HttpGet("getByLoginAndPassword")]
    [SwaggerOperation("Get user by login and password.")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetByLoginAndPassword([FromQuery] string login, [FromQuery] string password)
    {
        var result = await _mediator.Send(new GetUserByLoginAndPasswordQuery(login, password));

        return Ok(result);
    }

    [HttpPost]
    [SwaggerOperation("Add user")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> Post([FromBody] AddUserCommand command)
    {
        var result = await _mediator.Send(command);

        return Created($"api/users/{result.Id}", result);
    }

    [HttpPut]
    [SwaggerOperation("Update user")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Put([FromBody] UpdateUserCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [SwaggerOperation("Remove user")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveUserCommand(id));

        return NoContent();
    }
}
