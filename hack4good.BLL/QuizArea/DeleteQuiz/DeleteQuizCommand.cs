using MediatR;

namespace hack4good.BLL.QuizArea.DeleteQuiz;

public class DeleteQuizCommand : IRequest<Unit>
{
    public DeleteQuizCommand(Guid quizId)
    {
        QuizId = quizId;
    }

    public Guid QuizId { get; set; }
}