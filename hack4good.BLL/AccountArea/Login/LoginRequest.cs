using MediatR;

namespace hack4good.BLL.AccountArea.Login;

public class LoginRequest : IRequest<LoginResponse>
{
    public string Login { get; set; }

    public string Password { get; set; }
}