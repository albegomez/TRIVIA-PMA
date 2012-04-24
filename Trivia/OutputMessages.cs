using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public interface OutputMessages
    {
        void Add(string message);

        List<string> MessageQueue { get; set; }

        void PrintMessages();
    }
}
