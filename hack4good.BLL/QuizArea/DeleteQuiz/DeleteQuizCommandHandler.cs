using System.Linq;
using CoE.Db.Infrastructure;
using hack4good.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hack4good.BLL.QuizArea.DeleteQuiz;

public class DeleteQuizCommandHandler : IRequestHandler<DeleteQuizCommand, Unit>
{
    private readonly IRepository<QuizTour> _quizRepository;
    private readonly IRepository<QuizStep> _stepRepository;

    public DeleteQuizCommandHandler(IRepository<QuizTour> quizRepository, IRepository<QuizStep> stepRepository)
    {
        _quizRepository = quizRepository;
        _stepRepository = stepRepository;
    }

    public async Task<Unit> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = await _quizRepository.GetAll()
            .FirstOrDefaultAsync(q => q.Id == request.QuizId, cancellationToken);

        if (quiz is null)
        {
            throw new BusinessException("Quiz was not found");
        }
        
        var steps = await _stepRepository.GetAll()
            .Where(s => s.QuizId == request.QuizId)
            .ToListAsync(cancellationToken);

        await _stepRepository.Delete(steps);

        await _quizRepository.Delete(quiz);
        
        return Unit.Value;
    }
}