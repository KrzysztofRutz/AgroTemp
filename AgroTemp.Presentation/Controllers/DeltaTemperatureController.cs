using AgroTemp.Application.Commands.DeltaTemperatures.AddDeltaTemperature;
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

    [HttpPost]
    [SwaggerOperation("Add delta temperatures")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> Post()
    {
        var result = await _mediator.Send(new AddDeltaTemperatureCommand());

        return Created($"api/deltaTemperatures/{DateTime.Now}", result);
    }
}
