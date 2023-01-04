using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRabbitMQTest
{
    public class ObjectMsg
    {
       
        public ObjectMsg(Guid Id, String Message)
        {
            this.Id = Id;
            this.Message = Message;
        }

        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
