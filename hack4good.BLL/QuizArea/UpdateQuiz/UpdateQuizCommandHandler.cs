using CoE.Db.Infrastructure;
using hack4good.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hack4good.BLL.QuizArea.UpdateQuiz;

public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommand, Unit>
{
    private readonly IRepository<QuizTour> _quizRepository;
    private readonly IRepository<QuizStep> _stepRepository;

    public UpdateQuizCommandHandler(IRepository<QuizTour> quizRepository, IRepository<QuizStep> stepRepository)
    {
        _quizRepository = quizRepository;
        _stepRepository = stepRepository;
    }

    public async Task<Unit> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = await _quizRepository.GetAll()
            .FirstOrDefaultAsync(q => q.Id == request.Id, cancellationToken);

        if (quiz is null)
        {
            throw new BusinessException("Quiz was not found");
        }
        
        var steps = await _stepRepository.GetAll()
            .Where(s => s.QuizId == request.Id)
            .ToListAsync(cancellationToken);

        await _stepRepository.Delete(steps);

        quiz.Title = request.Title;
        quiz.Description = request.Description;
        
        await _stepRepository.Add(
            request.Steps.Select(s => new QuizStep()
            {
                Id = Guid.NewGuid(),
                QuizId = quiz.Id,
                Title = s.Title,
                Description = s.Description,
                Order = s.Order,
                ExternalId = s.ExternalId
            })
        );

        await _quizRepository.Update(quiz);
        
        return Unit.Value;
    }
}