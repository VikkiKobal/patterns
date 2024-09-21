using System;
using System.Collections.Generic;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
            List<string> blacklistNumbers = new List<string> { "123475454" };
            Blacklist blacklist = new Blacklist(blacklistNumbers);

            IMessageSender sender = new MessageSenderProxy(new MessageSender(), blacklist);

            TextMessage message1 = new TextMessage("Hello!", DateTime.Now, "123475454"); 
            TextMessage message2 = new TextMessage("Hi!!", DateTime.Now, "1234653");     

            try
            {
                sender.SendMessage(message1);
            }
            catch (BlacklistException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("--------------------------");

            try
            {
                sender.SendMessage(message2);
            }
            catch (BlacklistException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
