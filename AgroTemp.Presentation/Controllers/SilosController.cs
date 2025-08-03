using AgroTemp.Application.Commands.Silos.AddSilo;
using AgroTemp.Application.Commands.Silos.RemoveSilo;
using AgroTemp.Application.Commands.Silos.UpdateSilo;
using AgroTemp.Application.Dtos;
using AgroTemp.Application.Queries.Probes.GetProbesWithDetails;
using AgroTemp.Application.Queries.Silos.GetSiloById;
using AgroTemp.Application.Queries.Silos.GetSilos;
using AgroTemp.Application.Queries.Silos.GetSilosWithDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace AgroTemp.Presentation.Controllers;

[ApiController]
[Route("api/silos")]
public class SilosController : Controller
{
    private readonly IMediator _mediator;

    public SilosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerOperation("Get silos")]
    [ProducesResponseType(typeof(IEnumerable<SiloDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get()
    {
        var result = await _mediator.Send(new GetSilosQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    [SwaggerOperation("Get silo by Id")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetSiloByIdQuery(id));

        return Ok(result);
    }

    [HttpGet("[action]")]
    [SwaggerOperation("Get silos with details")]
    [ProducesResponseType(typeof(IEnumerable<SiloWithDetailsDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetWithDetails()
    {
        var result = await _mediator.Send(new GetSilosWithDetailsQuery());

        return Ok(result);
    }

    [HttpPost]
    [SwaggerOperation("Add silo")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> Post([FromBody] AddSiloCommand command)
    {
        var result = await _mediator.Send(command);

        return Created($"api/silos/{result.Id}", result);
    }

    [HttpPut]
    [SwaggerOperation("Update silo")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Put([FromBody] UpdateSiloCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [SwaggerOperation("Remove silo")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveSiloCommand(id));

        return NoContent();
    }
}
