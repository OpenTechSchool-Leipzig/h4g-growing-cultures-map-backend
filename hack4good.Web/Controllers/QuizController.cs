using hack4good.BLL.AccountArea.Login;
using hack4good.BLL.QuizArea.CreateQuiz;
using hack4good.BLL.QuizArea.GetQuizDetails;
using hack4good.BLL.QuizArea.GetQuizTours;
using hack4good.BLL.QuizArea.UpdateQuiz;
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

    [HttpPost]
    [SwaggerOperation("создать тур")]
    public async Task<IActionResult> Create([FromBody] CreateQuizCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPost]
    [SwaggerOperation("обновить тур")]
    public async Task<IActionResult> Update([FromBody] UpdateQuizCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }

    [HttpGet]
    [SwaggerOperation("получить детали тура")]
    public async Task<IActionResult> Details(Guid quizId)
    {
        var response = await _mediator.Send(new GetQuizDetailsRequest(quizId));

        return Ok(response);
    }
}