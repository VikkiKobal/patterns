using System;
using System.Collections.Generic;
using System.IO;

/*Клас Текстове повідомлення (текст повідомлення, час відправки, номер отримувача) */

    public class TextMessage
    {
    public string Text { get; set; }
    public DateTime SendTime { get; set; }
    public string ReceiverNumber { get; set; }

    public TextMessage(string text, DateTime sendTime, string receiverNumber)
    {
        Text = text;
        SendTime = sendTime;
        ReceiverNumber = receiverNumber;
    }
}
