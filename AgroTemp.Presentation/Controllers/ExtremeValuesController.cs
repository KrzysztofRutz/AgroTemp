using AgroTemp.Application.Commands.ExtremeValues.UpdateExtremeValues;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace AgroTemp.Presentation.Controllers;

[ApiController]
[Route("api/extremeValues")]
public class ExtremeValuesController : Controller
{
    private readonly IMediator _mediator;

    public ExtremeValuesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    [SwaggerOperation("Update extreme values.")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Put([FromBody]UpdateExtremeValuesCommand updateExtremeValuesCommand)
    {
        await _mediator.Send(updateExtremeValuesCommand);

        return NoContent();
    }
}
