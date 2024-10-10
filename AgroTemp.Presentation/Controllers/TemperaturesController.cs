using AgroTemp.Application.Commands.Temperatures.AddTemperature;
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

	[HttpPost]
	[SwaggerOperation("Add temperatures")]
	[ProducesResponseType((int)HttpStatusCode.Created)]
	public async Task<ActionResult> Post()
	{
		var result = await _mediator.Send(new AddTemperatureCommand());

		return Created($"api/temperatures/{DateTime.Now}", result);
	}
}
