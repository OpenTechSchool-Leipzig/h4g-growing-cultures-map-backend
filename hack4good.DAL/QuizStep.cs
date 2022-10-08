using hack4good.DAL.Misc;

namespace hack4good.DAL;

public class QuizStep : IdEntity
{
    public Guid QuizId { get; set; }

    public virtual QuizTour QuizTour { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Guid ExternalId { get; set; }

    public uint Order { get; set; }
}