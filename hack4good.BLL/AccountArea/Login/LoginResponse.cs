namespace hack4good.BLL.AccountArea.Login;

public class LoginResponse
{
    public Guid Id { get; set; }

    public Guid Token { get; set; }

    public bool IsAdmin { get; set; }
}