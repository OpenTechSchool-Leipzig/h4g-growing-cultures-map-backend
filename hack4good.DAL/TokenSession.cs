using hack4good.DAL.Misc;

namespace hack4good.DAL;

public class TokenSession : IdEntity
{
    public Guid AccountId { get; set; }

    public virtual Account Account { get; set; }

    public bool IsAdmin { get; set; }

    public DateTime IssuedAt { get; set; }

    public TimeSpan Duration { get; set; }

    public DateTime ValidUntil => IssuedAt.Add(Duration);
}