using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Entities
{
    public class Notification
    {
        private List<String> messages;

        public Notification()
        {
            messages = new List<String>();
        }

        public void add(String message)
        {
            messages.Add(message);
        }

        public void add(List<String> messages)
        {
            messages.Concat(messages);
        }

        public List<String> getMessages()
        {
            return messages;
        }

        public bool isEmpty()
        {
            return messages.Count == 0;
        }
    }
}
