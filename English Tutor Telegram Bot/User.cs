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
            Words = new List<Word>();
            LearningMode = false;
        }

        public User() { }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public long ChatId { get; set; }

        /// <summary>
        /// Сообщения, отправленные пользователем
        /// </summary>
        public List<Message> Messages { get; set; }

        /// <summary>
        /// Сохранённые пользователем слова
        /// </summary>
        public List<Word> Words { get; set; }

        /// <summary>
        /// Включён ли режим изучения слов
        /// </summary>
        public bool LearningMode { get; set; }

        /// <summary>
        /// Тренировка слов для данного пользователя
        /// </summary>
        [NonSerialized]
        public Training Training;
    }
}
