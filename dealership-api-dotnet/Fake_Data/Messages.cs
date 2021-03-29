using System.Collections.Generic;
using System.Data;
using System.Linq;
using dealership_app.Models;

namespace dealership_app.Fake_Data
{
    public class Messages
    {
        static private List<Message> messages = new List<Message>();

        static public List<Message> GetMessages()
        {
            if(messages.Count != 0)
            {
                return messages;
            }

            messages.Add(new Message(){
                name = "Firstmessage",
                phoneNumber = "11111111",
                email = "test@message.com",
                message = "hi, I am message"               
            });

           
            return messages;
        }

        static public List<Message> PostMessage(string name, string phoneNumber, string email, string message)
        {
            messages.Add(new Message(){
                name = name,
                phoneNumber = phoneNumber,
                email = email,
                message = message
            });

            return messages;
        }

    }
}