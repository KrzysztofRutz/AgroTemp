using AgroTemp.Application.Commands.Settings.UpdateFrequencyOfReading;
using AgroTemp.Application.Commands.Settings.UpdateHourOfReading;
using AgroTemp.Application.Commands.Settings.UpdateLanguage;
using AgroTemp.Application.Dtos;
using AgroTemp.Application.Queries.Settings.GetSettings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace AgroTemp.Presentation.Controllers;

[ApiController]
[Route("api/settings")]
public class SettingsController : Controller
{
    private readonly IMediator _mediator;

    public SettingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerOperation("Get settings")]
    [ProducesResponseType(typeof(IEnumerable<SettingsDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get()
    {
        var result = await _mediator.Send(new GetSettingsQuery());

        return Ok(result);
    }

    [HttpPatch("language")]
    [SwaggerOperation("Update language")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> PatchLanguage([FromBody]UpdateLanguageCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPatch("hourOfReading")]
    [SwaggerOperation("Update hour of reading")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> PatchHourOfReading([FromBody] UpdateHourOfReadingCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPatch("frequencyOfReading")]
    [SwaggerOperation("Update frequency of reading")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> PatchFrequencyOfReading([FromBody] UpdateFrequencyOfReadingCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }
}
