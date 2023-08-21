using AARProject.Application.Commands;
using AARProject.Application.Queries;
using AARProject.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class PointController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetPointQueryVM>> Get(Guid query)
    {
        var point = await Mediator.Send(new GetPointQuery() { Id = query });
        return Ok(point);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreatePointCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdatePointCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeletePointCommand() { Id = id });

        return NoContent();
    }
}
