namespace MinimalAPI.Shared.Exceptions;

public class LoginErrorsExceptions : BaseException
{
    public LoginErrorsExceptions() : base(ResourceErrorMessages.INVALID_LOGIN)
    {
    }
}
