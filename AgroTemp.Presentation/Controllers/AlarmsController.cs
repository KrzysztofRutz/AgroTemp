using AgroTemp.Application.Commands.Alarms.AddAlarm;
using AgroTemp.Application.Commands.Alarms.UpdateAlarm;
using AgroTemp.Application.Dtos;
using AgroTemp.Application.Queries.Alarms.GetActiveAlarms;
using AgroTemp.Application.Queries.Alarms.GetAlarmsByTimeInterval;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace AgroTemp.Presentation.Controllers;

[ApiController]
[Route("api/alarms")]
public class AlarmsController : Controller
{
    private readonly IMediator _mediator;

    public AlarmsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("active")]
    [SwaggerOperation("Get active alarms")]
    [ProducesResponseType(typeof(IEnumerable<AlarmDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetActive()
    {
        var result = await _mediator.Send(new GetActiveAlarmsQuery());

        return Ok(result);
    }

    [HttpGet()]
    [SwaggerOperation("Get history alarms by time interval.")]
    [ProducesResponseType(typeof(IEnumerable<AlarmDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetByTimeInterval([FromQuery]DateTime startDate, [FromQuery]DateTime endDate)
    {
        var result = await _mediator.Send(new GetAlarmsByTimeIntervalQuery(startDate, endDate));

        return Ok(result);
    }


    [HttpPost]
    [SwaggerOperation("Add alarm")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> Post([FromBody] AddAlarmCommand command)
    {
        var result = await _mediator.Send(command);

        return Created($"api/alarms/{result.Id}", result);
    }

    [HttpPut]
    [SwaggerOperation("Update alarm")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Put([FromBody] UpdateAlarmCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }
}
