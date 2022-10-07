using MediatR;

namespace hack4good.BLL.AccountArea.CreateAccount;

public class CreateAccountCommand : IRequest
{
    public string Login { get; set; }
    public string Password { get; set; }
}