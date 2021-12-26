using Telegram.Bot.Types;
namespace Telegram.Bot.Fadhil_riyanto_bot.Commands
{
    class Start
    {
        public static async Task<Message> Entry_point(ITelegramBotClient botClient, Message message)
        {
            string usage = "Hai :)\n" +
                "tulis /help jika kamu mau tahu menunya.";
            return await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: usage, replyToMessageId: message.MessageId, parseMode: Types.Enums.ParseMode.Html);
        }
    }
}

