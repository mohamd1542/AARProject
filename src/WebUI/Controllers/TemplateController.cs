using AARProject.Application.Commands;
using AARProject.Application.Queries;
using AARProject.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class TemplateController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetTemplateQueryVM>> Get(Guid query)
    {
        var user = await Mediator.Send(new GetTemplateQuery() { Id = query });
        return Ok(user);
    }

    [HttpGet("GetListTemplate")]
    public async Task<ActionResult<GetListOfTemplatesQueryVM>> GetListTemplate()
    {
        var listtemplate = await Mediator.Send(new GetListOfTemplatesQuery() { });
        return Ok(listtemplate);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateTemplateCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateTemplateCommand command)
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
        await Mediator.Send(new DeleteTemplateCommand() { Id = id });

        return NoContent();
    }
}
