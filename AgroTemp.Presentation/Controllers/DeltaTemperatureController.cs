using AgroTemp.Application.Commands.DeltaTemperatures.AddDeltaTemperature;
using AgroTemp.Application.Dtos;
using AgroTemp.Application.Queries.DeltaTemperatures.GetDeltaTemperaturesByProbeIdAndTimeInterval;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace AgroTemp.Presentation.Controllers;

[ApiController]
[Route("/api/deltaTemperatures")]
public class DeltaTemperatureController : Controller
{
    private readonly IMediator _mediator;

    public DeltaTemperatureController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerOperation("Get delta temperatures by probe id and time interval")]
    [ProducesResponseType(typeof(IEnumerable<DeltaTemperatureByIntervalTimeDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get([FromQuery] GetDeltaTemperaturesByProbeIdAndTimeIntervalQuery query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    [SwaggerOperation("Add delta temperatures")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> Post()
    {
        var result = await _mediator.Send(new AddDeltaTemperatureCommand());

        return Created($"api/deltaTemperatures/{DateTime.Now}", result);
    }
}
