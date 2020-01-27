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
            Bot = new Bot("953625679:AAEL-6Rbg3VG3R6d-k9fZWP68Iq8s4wKzpA");
            Bot.Start();
            Console.ReadLine();
        }
    }
}
