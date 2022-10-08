using CoE.Db.Infrastructure;
using hack4good.DAL;
using MediatR;

namespace hack4good.BLL.QuizArea.CreateQuiz;

public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, Guid>
{
    private readonly IRepository<QuizTour> _quizRepository;

    public CreateQuizCommandHandler(IRepository<QuizTour> quizRepository)
    {
        _quizRepository = quizRepository;
    }

    public async Task<Guid> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
    {
        var quizTour = new QuizTour()
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Steps = request.Steps.Select(s => new QuizStep()
            {
                Id = Guid.NewGuid(),
                Title = s.Title,
                Description = s.Description,
                Order = s.Order,
                ExternalId = s.ExternalId
            }).ToList()
        };

        await _quizRepository.Add(quizTour);
        
        return quizTour.Id;
    }
}