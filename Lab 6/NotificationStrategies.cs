using System;
using Task_6;

public class WhatsAppNotification : INotificationMethod
{
    public void Send(string message, string recipient)
    {
        Console.WriteLine($"Повідомлення WhatsApp надіслано {recipient}: {message}");
    }
}

public class EmailNotification : INotificationMethod
{
    public void Send(string message, string recipient)
    {
        Console.WriteLine($"Повідомлення на електронну пошту надіслано {recipient}: {message}");
    }
}

public class SMSNotification : INotificationMethod
{
    public void Send(string message, string recipient)
    {
        Console.WriteLine($"SMS-повідомлення надіслано {recipient}: {message}");
    }
}

public class TelegramNotification : INotificationMethod
{
    public void Send(string message, string recipient)
    {
        Console.WriteLine($"Повідомлення Telegram надіслано {recipient}: {message}");
    }
}
