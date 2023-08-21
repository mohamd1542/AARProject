using AARProject.Application.Commands;
using AARProject.Application.Queries;
using AARProject.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class CommentController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetCommentQueryVM>> Get(Guid query)
    {
        var user = await Mediator.Send(new GetCommentQuery() { Id = query });
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateCommentCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateCommentCommand command)
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
        await Mediator.Send(new DeleteCommentCommand() { Id = id });

        return NoContent();
    }
}
