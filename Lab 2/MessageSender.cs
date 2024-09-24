    using System.Collections.Generic;
    using System.IO;
    using System;

    public class BlacklistException : Exception
    {
        public BlacklistException(string receiverNumber)
            : base($"Cannot send message. The number {receiverNumber} is in the blacklist.")
        {
        }
    }

    public interface IMessageSender
    {
        bool SendMessage(TextMessage message);
    }

    public class MessageProxy : IMessageSender
    {
    private readonly IMessageSender _messageSender;
    private readonly string _filePath;

    public MessageProxy(IMessageSender messageSender, string filePath)
    {
        _messageSender = messageSender;
        _filePath = filePath;
    }

    public bool SendMessage(TextMessage message)
    {
        bool result = _messageSender.SendMessage(message);
        SaveMessageToFile(message);
        return result;
    }

    private void SaveMessageToFile(TextMessage message)
    {
        using (StreamWriter writer = File.AppendText(_filePath))
        {
            writer.WriteLine($"Message sent at {message.SendTime}: {message.Text} to {message.ReceiverNumber}");
        }
    }
}



    public class MessageSender : IMessageSender
    {
        public bool SendMessage(TextMessage message)
        {
            SaveMessageToFile(message);
            Console.WriteLine($"Message sent to {message.ReceiverNumber}: {message.Text}");
            return true;
        }

        private void SaveMessageToFile(TextMessage message)
        {
            string filePath = @"D:\file.txt";
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"Message sent at {message.SendTime}: {message.Text} to {message.ReceiverNumber}");
            }
        }
    }
    public class Blacklist
    {
        private readonly List<string> _blacklistedNumbers;

        public Blacklist(List<string> blacklist)
        {
            _blacklistedNumbers = new List<string>(blacklist);
        }

        public bool IsBlacklisted(string receiverNumber)
        {
            return _blacklistedNumbers.Contains(receiverNumber);
        }
    }


    public class MessageSenderProxy : IMessageSender
    {
        private readonly IMessageSender _messageSender;
        private readonly Blacklist _blacklist;

        public MessageSenderProxy(IMessageSender messageSender, Blacklist blacklist)
        {
            _messageSender = messageSender;
            _blacklist = blacklist;
        }

        public bool SendMessage(TextMessage message)
        {
            if (_blacklist.IsBlacklisted(message.ReceiverNumber))
            {
                throw new BlacklistException(message.ReceiverNumber);
            }

            return _messageSender.SendMessage(message);
        }
    }
