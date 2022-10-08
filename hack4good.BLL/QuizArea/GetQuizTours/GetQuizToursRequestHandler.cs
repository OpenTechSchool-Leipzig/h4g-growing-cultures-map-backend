using CoE.Db.Infrastructure;
using hack4good.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hack4good.BLL.QuizArea.GetQuizTours;

public class GetQuizToursRequestHandler : IRequestHandler<GetQuizToursRequest, ICollection<GetQuizToursResponseItem>>
{
    private readonly IRepository<QuizTour> _repository;

    public GetQuizToursRequestHandler(IRepository<QuizTour> repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<GetQuizToursResponseItem>> Handle(GetQuizToursRequest request, CancellationToken cancellationToken)
    {
        var quizTours = await _repository.GetAll()
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return quizTours.Select(q => new GetQuizToursResponseItem()
        {
            Id = q.Id,
            Title = q.Title,
            Description = q.Description
        }).ToList();
    }
}