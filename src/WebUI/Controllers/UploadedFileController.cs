using AARProject.Application.Commands;
using AARProject.Application.Queries;
using AARProject.Domain.Entities;
using AARProject.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class UploadedFileController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<GetFileQueryVM>> Get(Guid query)
    {
        var file= await Mediator.Send(new GetFileQuery() { Id=query});
        return Ok(file);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateFileCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateFileCommand command)
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
        await Mediator.Send(new DeleteFileCommand() { Id = id });

        return NoContent();
    }
}
