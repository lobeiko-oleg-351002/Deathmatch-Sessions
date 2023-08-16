namespace Infrastructure.Sessions.Exceptions;

public class NoUsersException : ServiceException
{
    public NoUsersException() : base("Users not found") { }
}
