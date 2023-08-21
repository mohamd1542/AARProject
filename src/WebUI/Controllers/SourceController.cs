using AARProject.Application.Commands;
using AARProject.Application.Common.Models;
using AARProject.Application.Queries;
using AARProject.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class SourceController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetSourceQueryVM>> Get(Guid query)
    {
        var user = await Mediator.Send(new GetSourceQuery() { Id = query });
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateSourceCommand command)
    {
        var id = await Mediator.Send(command);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateSourceCommand command)
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
        await Mediator.Send(new DeleteSourceCommand() { Id = id });

        return NoContent();
    }
}
