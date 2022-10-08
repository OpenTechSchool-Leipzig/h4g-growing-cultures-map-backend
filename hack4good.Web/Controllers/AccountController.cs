using hack4good.BLL.AccountArea.ChangeRole;
using hack4good.BLL.AccountArea.CreateAccount;
using hack4good.BLL.AccountArea.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hack4good.Web.Controllers;

public class AccountController : HackController
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [SwaggerOperation("логин")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var loginResponse = await _mediator.Send(request);

        return Ok(loginResponse);
    }

    [HttpPost]
    [SwaggerOperation("смена роли")]
    public async Task<IActionResult> ChangeRole([FromBody] ChangeRoleCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPost]
    [SwaggerOperation("создание аккаунта")]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }
}