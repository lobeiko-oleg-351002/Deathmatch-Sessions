using RabbitMQ.Client;
using System.Text;

namespace Application.Sessions.Messages
{
    public class RabbitMQProducer : IMessageProducer
    {
        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Users",
                               durable: false,
                               exclusive: false,
                               autoDelete: false,
                               arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                               routingKey: "Users",
                               basicProperties: null,
                               body: body);
            }
        }
    }
}
