namespace Glasno.User.Service.Application.Exceptions;

public class UserNotFoundException : ArgumentException
{
    public UserNotFoundException(string message) : base(message)
    {
    }
}