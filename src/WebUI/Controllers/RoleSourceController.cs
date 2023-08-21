using AARProject.Application.Commands;
using AARProject.Application.Queries;
using AARProject.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class RoleSourceController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateRoleSourceCommand command)
    {
        return await Mediator.Send(command);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteRoleSourceCommand() { Id = id });

        return NoContent();
    }
}
