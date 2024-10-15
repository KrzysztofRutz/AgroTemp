using AgroTemp.Application.Commands.Probes.AddProbe;
using AgroTemp.Application.Commands.Probes.RemoveProbe;
using AgroTemp.Application.Commands.Probes.UpdateProbe;
using AgroTemp.Application.Dtos;
using AgroTemp.Application.Queries.Probes.GetProbeById;
using AgroTemp.Application.Queries.Probes.GetProbes;
using AgroTemp.Application.Queries.Probes.GetProbesBySiloId;
using AgroTemp.Application.Queries.Probes.GetProbesWithDetails;
using AgroTemp.Application.Queries.Probes.GetProbesWithDetailsBySiloId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace AgroTemp.Presentation.Controllers;

[ApiController]
[Route("api/probes")]
public class ProbesController : Controller
{
    private readonly IMediator _mediator;

    public ProbesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerOperation("Get probes")]
    [ProducesResponseType(typeof(IEnumerable<ProbeDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get()
    {
        var result = await _mediator.Send(new GetProbesQuery());

        return Ok(result);
    }

    [HttpGet("[action]")]
    [SwaggerOperation("Get probes with details")]
    [ProducesResponseType(typeof(IEnumerable<ProbeWithDetailsDto>),(int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetWithDetails()
    {
        var result = await _mediator.Send(new GetProbesWithDetailsQuery());

        return Ok(result);
    }

    [HttpGet("[action]/{siloId}")]
    [SwaggerOperation("Get probes with details by siloId")]
    [ProducesResponseType(typeof(IEnumerable<ProbeWithDetailsDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetWithDetailsBySiloId([FromRoute]int siloId)
    {
        var result = await _mediator.Send(new GetProbesWithDetailsBySiloIdQuery(siloId));

        return Ok(result);
    }

    [HttpGet("{id}")]
    [SwaggerOperation("Get probe by Id")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetById([FromRoute]int id)
    {
        var result = await _mediator.Send(new GetProbeByIdQuery(id));

        return Ok(result);
    }

    [HttpGet("silo/{siloId}")]
    [SwaggerOperation("Get probe by siloId")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetBySiloId([FromRoute] int siloId)
    {
        var result = await _mediator.Send(new GetProbesBySiloIdQuery(siloId));

        return Ok(result);
    }

    [HttpPost]
    [SwaggerOperation("Add probe")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> Post([FromBody] AddProbeCommand command)
    {
        var result = await _mediator.Send(command);

        return Created($"api/probes/{result.Id}", result);
    }

    [HttpPut]
    [SwaggerOperation("Update probe")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Put([FromBody] UpdateProbeCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [SwaggerOperation("Remove probe")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Delete([FromRoute]int id)
    {
        await _mediator.Send(new RemoveProbeCommand(id));

        return NoContent();
    }
}
