namespace Infrastructure.Sessions.Exceptions;

public class ServiceException : Exception
{
    public ServiceException(string message) : base(message) { }
}
