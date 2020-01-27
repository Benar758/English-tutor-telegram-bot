using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace English_Tutor_Telegram_Bot
{
    /// <summary>
    /// Непосредственно бот
    /// </summary>
    public class Bot
    {
        /// <summary>
        /// Создание бота
        /// </summary>
        /// <param name="Token">Токен</param>
        public Bot(string Token)
        {
            this.Token = Token;
            Users = new List<User>();
        }

        public Bot() { }

        /// <summary>
        /// Токен
        /// </summary>
        private string Token { get; set; }

        /// <summary>
        /// Клиент телеграм-бота
        /// </summary>
        public static TelegramBotClient TelBot { get; set; }

        /// <summary>
        /// Пользователи, которые когда-либо обращались к боту
        /// </summary>
        public List<User> Users { get; set; }

        /// <summary>
        /// Приветствие нового пользователя
        /// </summary>
        private string Greeting = "Приветствую тебя, желающий изучать английский язык!" +
                                  $"{Environment.NewLine}Этот бот предназначен для того, чтобы тебе помочь в этом деле." +
                                  $"{Environment.NewLine}Вот, что он умеет: ";

        /// <summary>
        /// Функции бота
        /// </summary>
        private string Options = "* Укажите название времени, чтобы получить разъяснения с примерами." +
                                 $"{Environment.NewLine}Для примера: /Present_Simple." +
                                 $"{Environment.NewLine}* /word - Получить рандомное английское слово<" +
                                 $"{Environment.NewLine}* /idiom - Получить рандомную английскую идиому" +
                                 $"{Environment.NewLine}* /help - Вывести это сообщение ещё раз";

        /// <summary>
        /// Запускает бот и начинает принмать сообщения
        /// </summary>
        public void Start()
        {
            Data.Load();
            TelBot = new TelegramBotClient(Token);
            TelBot.OnMessage += MessageListener;
            TelBot.StartReceiving();
        }

        /// <summary>
        /// Приём сообщений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageListener(object sender, MessageEventArgs e)
        {
            bool newUser = false;

            string FirstName = e.Message.Chat.FirstName;
            string text = e.Message.Text;
            long id = e.Message.Chat.Id;
            string messageType = e.Message.Type.ToString();

            //Проверка на нового пользователя
            var selectedUser = from user in Users where user.ChatId == id select user;
            User tempUser = selectedUser.FirstOrDefault();

            if (tempUser == null)
            {
                Users.Add (new User(FirstName, id));
                tempUser = Users.Last();
                newUser = true;
            }

            User currentUser = tempUser;
            currentUser.Messages.Add(new Message(text, messageType, id));

            if (text == "/start")
            {
                if (newUser)
                {
                    Sender.SendTextMessage(id, Greeting);
                    Sender.SendTextMessage(id, Options);
                }
                else
                {
                    Sender.SendTextMessage(id, Options);
                }
            }
            else if (text.ToString().ToLower() == "/Present_simple".ToLower())
            {
                string picture = @"https://sun9-3.userapi.com/c857732/v857732380/15816b/t5tiWjLpCXA.jpg";
                Sender.SendPhoto(id, picture);
            }

            Data.Save();
        }
    }
}
