using CoE.Db.Infrastructure;
using hack4good.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hack4good.BLL.AccountArea.Login;

public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IRepository<Account> _repository;

    private readonly IRepository<TokenSession> _tokenSessionRepository;

    public LoginRequestHandler(IRepository<Account> repository, IRepository<TokenSession> tokenSessionRepository)
    {
        _repository = repository;
        _tokenSessionRepository = tokenSessionRepository;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var account = await _repository
            .GetAll()
            .FirstOrDefaultAsync(a => a.Login == request.Login, cancellationToken);

        if (account is null)
        {
            throw new BusinessException("Account not found");
        }
        
        if (account.Password != request.Password)
        {
            throw new BusinessException("Invalid password");
        }

        var tokenSession = new TokenSession()
        {
            Id = Guid.NewGuid(),
            AccountId = account.Id,
            IsAdmin = account.IsAdmin,
            IssuedAt = DateTime.UtcNow,
            Duration = TimeSpan.FromDays(1)
        };

        await _tokenSessionRepository.Add(tokenSession);

        return new LoginResponse()
        {
            Id = account.Id,
            Token = tokenSession.Id,
            IsAdmin = account.IsAdmin
        };
    }
}