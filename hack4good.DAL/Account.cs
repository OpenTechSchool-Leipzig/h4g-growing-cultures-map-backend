using hack4good.DAL.Misc;

namespace hack4good.DAL;

public class Account : IdEntity
{
    public string Login { get; set; }

    public string Password { get; set; }

    public bool IsAdmin { get; set; }

    public virtual ICollection<TokenSession> TokenSessions { get; set; }
}