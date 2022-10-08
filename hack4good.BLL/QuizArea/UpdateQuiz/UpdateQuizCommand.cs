using MediatR;

namespace hack4good.BLL.QuizArea.UpdateQuiz;

public class UpdateQuizCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }

    public string Description { get; set; }

    public ICollection<QuizStepDetail> Steps { get; set; }
}