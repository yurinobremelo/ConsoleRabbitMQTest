using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRabbitMQTest
{
    public class Receiver
    {
        public void Consume()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                   
                    channel.QueueDeclare(queue: "order",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                    var data =  channel.BasicGet("order", true);
                    var json = Encoding.UTF8.GetString(data.Body.ToArray());
                    var obj = JsonConvert.DeserializeObject<ObjectMsg>(json);
                   

                    Console.WriteLine(obj.Message);

                }
            }






        }





    }
}
