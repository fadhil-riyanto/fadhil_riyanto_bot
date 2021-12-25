
using System.Diagnostics;
using Telegram.Bot.Types;

namespace Telegram.Bot.Fadhil_riyanto_bot.Utils
{
    public class Utils
    { //entends
        protected Message? message;
        public Dictionary<string, string> input_telegram = new Dictionary<string, string>();
        public Utils(Message _message) => (message) = _message;
        public Dictionary<string, string> get_command(string? text, char prefix = '/')
        {
            Debug.Assert(text != null, nameof(text) + " != null");
            if (text[0] == '/' && text != null)
            {
                string[] hasilSplit = text.Split(' ');
                if (hasilSplit.Length != 1)
                {
                    input_telegram.Add("command", hasilSplit[1]);
                    input_telegram.Add("value", hapus_kata_dari_depan(text));
                    input_telegram.Add("error", "false");
                }
                else
                {
                    input_telegram.Add("command", hasilSplit[1]);
                    input_telegram.Add("value", "null");
                    input_telegram.Add("error", "false");
                }
            }
            else
            {
                input_telegram.Add("command", "null");
                input_telegram.Add("value", "null");
                input_telegram.Add("error", "true");
            }
            return input_telegram;
        }
        private static string hapus_kata_dari_depan(string word, int jumlah_crop_word = 1)
        {
            int i = word.IndexOf(" ") + jumlah_crop_word;
            string? str = word.Substring(i);
            return str;
        }
    }
}