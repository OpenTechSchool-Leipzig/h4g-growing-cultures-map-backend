using MediatR;

namespace hack4good.BLL.QuizArea.GetQuizTours;

public class GetQuizToursRequest : IRequest<ICollection<GetQuizToursResponseItem>>
{
}