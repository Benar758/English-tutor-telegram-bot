using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_Tutor_Telegram_Bot
{
    class Program
    {
        public static Bot Bot;

        static void Main(string[] args)
        {
            Bot = new Bot("###");
            Bot.Start();
            Console.ReadLine();
        }
    }
}
