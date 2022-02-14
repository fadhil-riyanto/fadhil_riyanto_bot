using Telegram.Bot.Types;
using System.Web;
using Newtonsoft.Json;
namespace Telegram.Bot.Fadhil_riyanto_bot.Commands
{
    class Xjson
    {
        public static async Task<Message> Entry_point(ITelegramBotClient botClient, Message message)
        {
            var root = new xjsontostr { Messages = new List<Message> { message } };
            string json = JsonConvert.SerializeObject(root, Formatting.Indented);

            return await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: HttpUtility.HtmlEncode(json), replyToMessageId: message.MessageId, parseMode: Types.Enums.ParseMode.Html);
        }
    }
    public class xjsontostr
    {

        [JsonProperty("Message")]
        public List<Message> Messages { get; set; }
    }


}

