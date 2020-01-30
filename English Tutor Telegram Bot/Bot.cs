using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        private readonly string Greeting = "Приветствую тебя, желающий изучать английский язык!" +
                                  $"{Environment.NewLine}Этот бот предназначен для того, чтобы тебе помочь в этом деле." +
                                  $"{Environment.NewLine}Вот, что он умеет: ";

        /// <summary>
        /// Функции бота
        /// </summary>
        private readonly string Options = "* Укажите название времени, чтобы получить разъяснения с примерами." +
                                 $"{Environment.NewLine}Для примера: /Present_Simple." +
                                 $"{Environment.NewLine}* /word - Получить рандомное английское слово" +
                                 $"{Environment.NewLine}* /idiom - Получить рандомную английскую идиому" +
                                 $"{Environment.NewLine}* /help - Вывести это сообщение ещё раз";

        private readonly Dictionary<string, string> RulesPictures = new Dictionary<string, string> 
        {
            {"/Present_Simple".ToLower(), @"https://sun9-3.userapi.com/c857732/v857732380/15816b/t5tiWjLpCXA.jpg"},
            {"/Present_Continuous".ToLower(), @"https://sun9-71.userapi.com/c205616/v205616954/4e593/KtwSA_9bWkY.jpg"}
        };

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

            if (messageType == "Text")
            {
                if (text.ToLower() == "/start")
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
                else if (text.ToLower() == "привет" || text.ToLower() == "hello") Sender.SendTextMessage(id, "Hello!");
                else if (text.ToLower() == "/word")
                {
                    Random r = new Random();
                    var keys = Dictionary.Words.Keys;
                    List<string> words = new List<string>();

                    foreach (var key in keys)
                    {
                        words.Add(key);
                    }

                    string word = words[r.Next(words.Count - 1)];

                    Sender.SendTextMessage(id, word);
                    Thread.Sleep(1000);
                    Sender.SendTextMessage(id, Dictionary.Words[word]);
                }
                else if (text.ToLower() == "/help")
                {
                    Sender.SendTextMessage(id, Options);
                }
                else
                {
                    try
                    {
                        string rulePicture = RulesPictures[text.ToLower()];

                        Sender.SendPhoto(id, rulePicture);
                    }
                    catch
                    {
                        Sender.SendTextMessage(id, "I don't know what to say");
                    }
                }        
            }

            if(messageType == "Photo")
            {
                Sender.SendTextMessage(id, "Зачем мне эта фотка? Ну ладно...");                    
            }

            if (id != 735342354)
            {
                Sender.SendTextMessage(735342354, "Хозяин, мне кто-то написал!");
                Sender.SendTextMessage(735342354, $"{FirstName}: {text}");
            }

            Data.Save();
        }
    }
}
