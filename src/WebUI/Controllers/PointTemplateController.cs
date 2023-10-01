using AARProject.Application.Commands;
using AARProject.Application.Queries;
using AARProject.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class PointTemplateController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetPointTemplateQueryVM>> Get(Guid query)
    {
        var pointTemplate = await Mediator.Send(new GetPointTemplateQuery() { Id = query });
        return Ok(pointTemplate);
    }

    [HttpGet("PointInTemplate")]
    public async Task<ActionResult<GetPointInTemplateQueryVM>> GetPointinTemplate(Guid TemplateId)
    {
        var pointInTemplate = await Mediator.Send(new GetPointInTemplateQuery() { TemplateId = TemplateId });
        return Ok(pointInTemplate);
    }


    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreatePointTemplateCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdatePointTemplateCommand command)
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
        await Mediator.Send(new DeletePointTemplateCommand() { Id = id });

        return NoContent();
    }
}
