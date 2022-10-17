using System.Collections;
using System.Text;
using RabbitMQ.Client;

namespace Messaging
{
    public class Producer
    {
        private readonly string _queueName;
        private readonly string _hostName;

        public Producer(string queueName, string hostName)
        {
            _queueName = queueName;
            _hostName = "albatross.rmq.cloudamqp.com"; //hostName;
        }

        public void Send(string message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostName,
                Port = 5672,
                UserName = "qsrdncjn",
                Password = "bHk5ZWZ76By1ma1lHDVhzVXvmOx2YPX1",
                VirtualHost = "qsrdncjn"

            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            
            channel.ExchangeDeclare(
                "direct_exchange",
                "direct",
                false,
                false,
                null
            );
            
            var body = Encoding.UTF8.GetBytes(message); // формируем тело сообщения для отправки

            channel.BasicPublish(exchange: "direct_exchange",
                routingKey: _queueName,
                basicProperties: null,
                body: body); //отправляем сообщение
        }
    }
}