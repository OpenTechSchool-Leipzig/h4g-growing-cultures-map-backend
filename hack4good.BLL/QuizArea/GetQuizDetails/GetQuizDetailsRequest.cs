using MediatR;

namespace hack4good.BLL.QuizArea.GetQuizDetails;

public class GetQuizDetailsRequest : IRequest<GetQuizDetailsResponse>
{
    public GetQuizDetailsRequest(Guid quizId)
    {
        QuizId = quizId;
    }

    public Guid QuizId { get; set; }
}