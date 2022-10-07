using CoE.Db.Infrastructure;
using hack4good.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hack4good.BLL.AccountArea.CreateAccount;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand>
{
    private readonly IRepository<Account> _repository;

    public CreateAccountCommandHandler(IRepository<Account> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = new Account()
        {
            Login = request.Login,
            Password = request.Password
        };

        try
        {
            await _repository.Add(account);
        }
        catch (DbUpdateException ex)
        {
            throw new BusinessException("Failed creating account");
        }

        return Unit.Value;
    }
}