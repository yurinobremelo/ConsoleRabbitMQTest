using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;

namespace ConsoleRabbitMQTest
{
    public class Publisher
    {

        public void Publish(ObjectMsg obj)
        {

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            { 
                using (var channel = connection.CreateModel())
                {
                    channel.ConfirmSelect();
                    channel.BasicAcks += Event_Confirm;
                    channel.BasicNacks += Event_NotConfirm;

                    channel.QueueDeclare(queue: "order",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                    var json = JsonConvert.SerializeObject(obj);
                    var content = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "",
                                        routingKey: "order",
                                        basicProperties: null,
                                        body: content);

                    Console.WriteLine("Message Send !");
                
                }
            }
        }

        private void Event_Confirm(object sender, BasicAckEventArgs e)
        {
            Console.WriteLine("Ack");

        }
        private void Event_NotConfirm(object sender, BasicNackEventArgs e)
        {
            Console.WriteLine("Nack");

        }
    }
}
