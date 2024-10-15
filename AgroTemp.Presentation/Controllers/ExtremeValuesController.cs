using AgroTemp.Application.Commands.ExtremeValues.UpdateExtremeValues;
using AgroTemp.Application.Dtos;
using AgroTemp.Application.Queries.ExtremeValues.GetExtremeValues;
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

    [HttpGet]
    [SwaggerOperation("Get extreme values.")]
    [ProducesResponseType(typeof(IEnumerable<ExtremeValuesDto>),(int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get()
    {
        var result = await _mediator.Send(new GetExtremeValuesQuery());

        return Ok(result);
    }
}
