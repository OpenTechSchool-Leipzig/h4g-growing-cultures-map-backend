namespace hack4good.BLL.Services;

public interface ISessionHolder
{
    public Guid TokenId { get; }

    public Guid AccountId { get; }

    void Set(Guid token, Guid account);
}