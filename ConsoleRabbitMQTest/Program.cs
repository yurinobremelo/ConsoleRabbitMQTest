using System;
using System.Security.Cryptography;
using RabbitMQ.Client;


namespace ConsoleRabbitMQTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var msgSend = new ObjectMsg (Guid.NewGuid(),"Message Test " + new Random().Next(1,5).ToString());
               
                new Publisher().Publish(msgSend);
                new Receiver().Consume();

                Console.WriteLine(" Press enter");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
       
    }
}
