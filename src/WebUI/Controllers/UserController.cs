using AARProject.Application.Commands;
using AARProject.Application.Model;
using AARProject.Application.Queries;
using AARProject.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class UserController : ApiControllerBase
{
    [HttpPost("RefreshToken")]
    public async Task<ActionResult<string>> CreateUser(AuthenticatedResponse authRes)
    {
        var createRefreshToken = await Mediator.Send(new CreateRefreshTokenItem() { AccessToken = authRes.Token , RefreshToken = authRes.RefreshToken});
        if (createRefreshToken == null)
        {
            return NotFound();
        }
        return Ok(new AuthenticatedResponse()
        {
            Token = createRefreshToken.Token,
            RefreshToken = createRefreshToken.RefreshToken
        });
    }



    [HttpPost("Token")]
    public async Task<ActionResult<string>> CreateUser(LoginModel auth)
    {
        var createToken = await Mediator.Send(new CreateTokenItem() { Email = auth.Email , Password = auth.Password });
        if (createToken == null)
        {
            return NotFound();
        }
        return Ok(new AuthenticatedResponse()
        {
            Token = createToken.AccessToken,
            RefreshToken = createToken.RefresToken
        });
    }

    [HttpGet]
    public async Task<ActionResult<GetUserQueryVM>> Get(Guid query)
    {
        var user = await Mediator.Send(new GetUserQuery() { Id = query });
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateUserCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateUserCommand command)
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
        await Mediator.Send(new DeleteUserCommand() { Id = id });

        return NoContent();
    }
}
