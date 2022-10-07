using MediatR;

namespace hack4good.BLL.AccountArea.ChangeRole;

public class ChangeRoleCommand : IRequest<Unit>
{
    public Guid AccountId { get; set; }

    public bool IsAdmin { get; set; }
}