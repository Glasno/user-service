namespace Glasno.User.Service.Domain.Exceptions;

public class UserNotFoundException : ArgumentException
{
    public UserNotFoundException(string message) : base(message)
    {
    }
}