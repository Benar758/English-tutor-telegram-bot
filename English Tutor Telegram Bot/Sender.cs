using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_Tutor_Telegram_Bot
{
    /// <summary>
    /// Отправщик сообщений
    /// </summary>
    class Sender
    {
        /// <summary>
        /// Отправляет текстовое сообщение
        /// </summary>
        /// <param name="chatId">Id</param>
        /// <param name="Text">Текст сообщения</param>
        public async static void SendTextMessage(long chatId, string Text)
        {
            await Bot.TelBot.SendTextMessageAsync(chatId, Text);
        }

        /// <summary>
        /// Отправляет картинку
        /// </summary>
        /// <param name="chatId">Id</param>
        /// <param name="PhotoUrl">Ссылка на картинку</param>
        public async static void SendPhoto(long chatId, string PhotoUrl)
        {
            await Bot.TelBot.SendPhotoAsync(chatId, PhotoUrl);
        }
    }
}
