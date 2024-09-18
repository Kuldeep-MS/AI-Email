using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Email
{
    public class Message
    {
        public string SenderEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime TimeStamp { get; set; }

        public override string ToString()
        {
            return SenderEmail+ " : "+Subject + "\t\t" +TimeStamp.ToString();
        }
    }
}
