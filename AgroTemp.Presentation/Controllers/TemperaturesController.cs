using AgroTemp.Application.Commands.Temperatures.AddTemperature;
using AgroTemp.Application.Dtos;
using AgroTemp.Application.Queries.Temperatures.GetTemperaturesByTimeInterval;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace AgroTemp.Presentation.Controllers;

[ApiController]
[Route("api/temperatures")]
public class TemperaturesController : Controller
{
	private readonly IMediator _mediator;

	public TemperaturesController(IMediator mediator)
    {
		_mediator = mediator;
	}

	[HttpGet]
    [SwaggerOperation("Get temperatures by probe id and time interval")]
    [ProducesResponseType(typeof(IEnumerable<TemperatureByIntervalTimeDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get([FromQuery] GetTemperaturesByProbeIdAndTimeIntervalQuery query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
	[SwaggerOperation("Add temperatures")]
	[ProducesResponseType((int)HttpStatusCode.Created)]
	public async Task<ActionResult> Post()
	{
		var result = await _mediator.Send(new AddTemperatureCommand());

		return Created($"api/temperatures/{DateTime.Now}", result);
	}
}
