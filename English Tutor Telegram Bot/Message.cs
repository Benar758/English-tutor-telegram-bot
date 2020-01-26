using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_Tutor_Telegram_Bot
{
    class Message
    {
        public Message(string Text, string MessageType, long ChatId)
        {
            this.Text = Text;
            this.MessageType = MessageType;
            this.ChatId = ChatId;
        }

        public string Text { get; set; }

        public string MessageType { get; set; }

        public long ChatId { get; set; }
    }
}
