namespace hack4good.BLL;

public class BusinessException : Exception
{
    public BusinessException(string message) : base(message)
    {
    }
}