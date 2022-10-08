using hack4good.DAL.Misc;

namespace hack4good.DAL;

public class QuizTour : IdEntity
{
    public string Title { get; set; }

    public string Description { get; set; }

    public virtual ICollection<QuizStep> Steps { get; set; }
}