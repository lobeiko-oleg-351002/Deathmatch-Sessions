namespace Application.Sessions.Messages
{
    public interface IMessageProducer
    {
        void SendMessage(string message);
    }
}
