using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_Tutor_Telegram_Bot
{
    class User
    {
        public User(string Name, long ChatId, Message LastMesssage)
        {
            this.Name = Name;
            this.ChatId = ChatId;
            this.LastMessage = LastMesssage;
        }

        public string Name { get; set; }

        public long ChatId { get; set; }

        public Message LastMessage { get; set; }
    }
}
