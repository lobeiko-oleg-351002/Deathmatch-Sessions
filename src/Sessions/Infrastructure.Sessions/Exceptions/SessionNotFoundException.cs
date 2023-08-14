namespace Infrastructure.Sessions.Exceptions;

public class SessionNotFoundException : ServiceException
{
    public SessionNotFoundException() : base("Session not found") { }
}
