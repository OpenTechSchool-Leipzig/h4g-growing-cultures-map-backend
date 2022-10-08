namespace hack4good.BLL.QuizArea.GetQuizDetails;

public class GetQuizDetailsResponse
{
    public string Title { get; set; }

    public string Description { get; set; }

    public ICollection<QuizStepDetail> Steps { get; set; }
}