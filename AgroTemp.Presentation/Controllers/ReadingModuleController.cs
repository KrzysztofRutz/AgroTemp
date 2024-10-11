using AgroTemp.Application.Commands.ReadingModules.AddReadingModule;
using AgroTemp.Application.Commands.ReadingModules.RemoveReadingModule;
using AgroTemp.Application.Commands.ReadingModules.UpdateReadingModule;
using AgroTemp.Application.Dtos;
using AgroTemp.Application.Queries.ReadingModules.GetReadingModuleById;
using AgroTemp.Application.Queries.ReadingModules.GetReadingModules;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace AgroTemp.Presentation.Controllers;

[ApiController]
[Route("api/readingModules")]
public class ReadingModuleController : Controller
{
    private readonly IMediator _mediator;

    public ReadingModuleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerOperation("Get reading modules")]
    [ProducesResponseType(typeof(IEnumerable<ReadingModuleDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get()
    {
        var result = await _mediator.Send(new GetReadingModulesQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    [SwaggerOperation("Get reading module by Id")]
    [ProducesResponseType(typeof(ReadingModuleDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetReadingModuleByIdQuery(id));

        return Ok(result);
    }

    [HttpPost]
    [SwaggerOperation("Add reading module")]
    [ProducesResponseType(typeof(ReadingModuleDto), (int)HttpStatusCode.Created)]
    public async Task<ActionResult> Post([FromBody] AddReadingModuleCommand command)
    {
        var result = await _mediator.Send(command);

        return Created($"api/readingModules/{result.Id}", result);
    }

    [HttpPut]
    [SwaggerOperation("Update reading module")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Put([FromBody] UpdateReadingModuleCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [SwaggerOperation("Remove reading module")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveReadingModuleCommand(id));

        return NoContent();
    }
}
