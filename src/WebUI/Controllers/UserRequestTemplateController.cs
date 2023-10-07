using AARProject.Application.Commands;
using AARProject.Application.Queries;
using AARProject.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class UserRequestTemplateController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetUserRequestTemplateQueryVM>> Get(Guid query)
    {
        var user = await Mediator.Send(new GetUserRequestTemplateQuery() { Id = query });
        return Ok(user);
    }

    [HttpGet("TemplatesFroUser")]
    public async Task<ActionResult<GetlistforuserQueryVM>> GetListTforR(Guid query)
    {
        var listTforU = await Mediator.Send(new GetlistforuserQuery() { UserId = query });
        return Ok(listTforU);
    }


    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateUserRequestTemplateCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateUserRequestTemplateCommand command)
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
        await Mediator.Send(new DeleteUserRequestTemplateCommand() { Id = id });

        return NoContent();
    }
}
