using AARProject.Application.Commands;
using AARProject.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class UserRoleController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateUserRoleCommand command)
    {
        return await Mediator.Send(command);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteUserRoleCommand() { Id = id });
        return NoContent();
    }
}
