using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_Tutor_Telegram_Bot
{
    class Data
    {
        public static void Save()
        {
            string json = JsonConvert.SerializeObject(Program.Bot.Users);
            File.WriteAllText("data.json", json);
        }

        public static void Load()
        {
            if (!File.Exists("data.json")) File.Create("data.json").Dispose();
            string json = File.ReadAllText("data.json");
            if (!string.IsNullOrEmpty(json)) Program.Bot.Users = JsonConvert.DeserializeObject<List<User>>(json);
        }
    }
}
