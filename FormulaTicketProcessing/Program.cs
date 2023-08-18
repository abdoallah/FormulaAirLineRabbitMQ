
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Hello ======== WELCOME TO BOOKING WEBSITE ======= ");

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "USER",
    Password = "PASSWORD",
    VirtualHost = "/"
};
var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueDeclare("Booking", durable: true, exclusive: true);
var  consumer  = new EventingBasicConsumer(channel);
consumer.Received += (sender, args) =>
{
    //getting  body  as byte  array 
    var body = args.Body.ToArray();
    var  messsage = Encoding.UTF8.GetString(body);
    Console.WriteLine(messsage);
};
channel.BasicConsume("Booking", true, consumer);

Console.ReadKey();
