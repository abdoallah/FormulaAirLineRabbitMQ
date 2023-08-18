using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace FormulaAirLine.Services
{
    public class MassageProducer : IMassageProducer
    {
        public void SendingMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "user",
                Password = "password",
                VirtualHost = "/"
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("Booking",durable:true, exclusive:true);
            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);
            channel.BasicPublish("", "Booking", body: body);
        }
    }
}
