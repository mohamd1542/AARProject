using AARProject.Application.Commands;
using AARProject.Application.Queries;
using AARProject.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class UserRpointTemplateController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetUserRpointTemplateQueryVM>> Get(Guid query)
    {
        var user = await Mediator.Send(new GetUserRpointTemplateQuery() { Id = query });
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateUserRpointTemplateCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateUserRpointTemplateCommand command)
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
        await Mediator.Send(new DeleteUserRpointTemplateCommand() { Id = id });

        return NoContent();
    }
}
