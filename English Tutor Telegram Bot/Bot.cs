using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace English_Tutor_Telegram_Bot
{
    class Bot
    {
        public Bot(string Token)
        {
            this.Token = Token;
            Users = new List<User>();
        }

        private string Token { get; set; }

        private TelegramBotClient TelBot { get; set; }

        private List<User> Users { get; set; }

        private string Greeting = "Приветствую тебя, желающий изучать английский язык!" +
                                  $"{Environment.NewLine}Этот бот предназначен для того, чтобы тебе помочь в этом деле." +
                                  $"{Environment.NewLine}Вот, что он умеет: ";

        private string Options = "* Укажите название времени, чтобы получить разъяснения с примерами." +
                                 $"{Environment.NewLine}Для примера: /Present_Simple." +
                                 $"{Environment.NewLine}* /word - Получить рандомное английское слово" +
                                 $"{Environment.NewLine}* /idiom - Получить рандомную английскую идиому" +
                                 $"{Environment.NewLine}* /help - Вывести это сообщение ещё раз";

        public void Start()
        {
            TelBot = new TelegramBotClient(Token);
            TelBot.OnMessage += MessageListener;
            TelBot.StartReceiving();
        }

        private void MessageListener(object sender, MessageEventArgs e)
        {
            var selectedUser = from user in Users where user.ChatId == e.Message.Chat.Id select user;
            

            if (selectedUser.FirstOrDefault() == null) Users.Add
                                                      (
                 new User(e.Message.Chat.FirstName, e.Message.Chat.Id,
                 new Message(e.Message.Text, e.Message.Type.ToString(), e.Message.Chat.Id))
                                                      );

            selectedUser = from user in Users where user.ChatId == e.Message.Chat.Id select user;
            User currentUser = selectedUser.FirstOrDefault();
            currentUser.LastMessage.Text = e.Message.Text;

            string text = currentUser.LastMessage.Text;
            long id = currentUser.ChatId;
            string messageType = currentUser.LastMessage.MessageType;


            if (text == "/start")
            {
               TelBot.SendTextMessageAsync(id, Greeting);
               TelBot.SendTextMessageAsync(id, Options);
            }

            if (text.ToString() == "present simple")
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(new Uri("https://fb.ru/misc/i/gallery/31654/2940348.jpg"), "table.jpg");

                FileStream fs = new FileStream("table.jpg", FileMode.Open);

                TelBot.SendPhotoAsync(id, fs);

                fs.Close();
                fs.Dispose();
            }
        }
    }
}
