

using Telegram.Bot.Types;

namespace Telegram.Bot.Fadhil_riyanto_bot.Utils{
    public class Utils{
        private Message? message;
        public Dictionary<string, string> input_telegram = new Dictionary<string, string>();
        Utils(Message _message) => (message) = _message;

        public Dictionary<string, string> get_command()
        {
            

            return input_telegram;
        }
    }
}