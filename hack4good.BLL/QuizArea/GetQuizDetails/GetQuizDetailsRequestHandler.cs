using CoE.Db.Infrastructure;
using hack4good.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hack4good.BLL.QuizArea.GetQuizDetails;

public class GetQuizDetailsRequestHandler : IRequestHandler<GetQuizDetailsRequest, GetQuizDetailsResponse>
{
    private readonly IRepository<QuizTour> _repository;

    public GetQuizDetailsRequestHandler(IRepository<QuizTour> repository)
    {
        _repository = repository;
    }

    public async Task<GetQuizDetailsResponse> Handle(GetQuizDetailsRequest request, CancellationToken cancellationToken)
    {
        var quizTour = await _repository.GetAll()
            .Include(q => q.Steps.OrderBy(s => s.Order))
            .FirstOrDefaultAsync(q => q.Id == request.QuizId, cancellationToken: cancellationToken);

        if (quizTour is null)
        {
            throw new BusinessException("Quiz was not found");
        }

        return new GetQuizDetailsResponse()
        {
            Title = quizTour.Title,
            Description = quizTour.Description,
            Steps = quizTour.Steps.Select(s => new QuizStepDetail()
            {
                Title = s.Title,
                Description = s.Description,
                Order = s.Order,
                ExternalId = s.ExternalId
            }).ToList()
        };
    }
}