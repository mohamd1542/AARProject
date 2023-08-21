using AARProject.Application.Commands;
using AARProject.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class RoleTemplateController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateRoleTemplateCommand command)
    {
        return await Mediator.Send(command);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteRoleTemplateCommand() { Id = id });
        return NoContent();
    }
}
