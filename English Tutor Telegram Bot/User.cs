using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_Tutor_Telegram_Bot
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <param name="ChatId">Id</param>
        /// <param name="LastMesssage">Сообщение</param>
        public User(string Name, long ChatId)
        {
            this.Name = Name;
            this.ChatId = ChatId;
            Messages = new List<Message>();
        }

        public User() { }

        public string Name { get; set; }

        public long ChatId { get; set; }

        public List<Message> Messages { get; set; }
    }
}
