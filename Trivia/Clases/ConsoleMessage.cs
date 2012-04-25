using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class ConsoleMessage:OutputMessages
    {
        public void Add(string message)
        {
            this.MessageQueue.Add(message);
        }




        public void PrintMessages()
        {
            foreach (var message in this.messageQueue)
            {
                Console.WriteLine(message);
            }   
        }




        private List<string> messageQueue;
        public List<string> MessageQueue
        {
            get
            {
                if (this.messageQueue == null)
                    this.messageQueue = new List<string>();
                return this.messageQueue;
            }
            set
            {
                this.messageQueue = value;
            }
        }
    }
}
