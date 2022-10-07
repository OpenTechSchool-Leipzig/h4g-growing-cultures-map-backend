using CoE.Db.Infrastructure;
using hack4good.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hack4good.BLL.AccountArea.ChangeRole;

public class ChangeRoleCommandHandler : IRequestHandler<ChangeRoleCommand, Unit>
{
    private readonly IRepository<Account> _repository;

    public ChangeRoleCommandHandler(IRepository<Account> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(ChangeRoleCommand request, CancellationToken cancellationToken)
    {
        var account = await _repository.GetAll().FirstOrDefaultAsync(a => a.Id == request.AccountId, cancellationToken: cancellationToken);

        if (account is null)
        {
            throw new BusinessException("Account not found");
        }

        account.IsAdmin = request.IsAdmin;

        await _repository.Update(account);
        
        return Unit.Value;
    }
}