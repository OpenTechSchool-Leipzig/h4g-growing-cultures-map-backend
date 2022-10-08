using hack4good.BLL.AccountArea.Login;
using hack4good.BLL.QuizArea.GetQuizTours;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hack4good.Web.Controllers;

public class QuizController : HackController
{
    private readonly IMediator _mediator;

    public QuizController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerOperation("список туров")]
    public async Task<IActionResult> List()
    {
        var response = await _mediator.Send(new GetQuizToursRequest());

        return Ok(response);
    }
}