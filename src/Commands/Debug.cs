using Telegram.Bot.Types;

namespace Telegram.Bot.Fadhil_riyanto_bot.Commands
{
    class Debug
    {
        public static async Task<Message> Entry_point(ITelegramBotClient botClient, Message message)
        {
            Utils.Utils util = new Telegram.Bot.Fadhil_riyanto_bot.Utils.Utils(message);
            Dictionary<string, string> test_crop = util.get_command(message.Text);
            // Utils.UAdmin_utils UAdmin_utils = new Telegram.Bot.Fadhil_riyanto_bot.Utils.UAdmin_utils(message, botClient);
            // bool testadmin = await UAdmin_utils.is_admin();

            Utils.Utils utils = new Telegram.Bot.Fadhil_riyanto_bot.Utils.Utils(message);
            bool testadmin = utils.is_grup();
            return await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: testadmin.ToString());
        }
    }
}

