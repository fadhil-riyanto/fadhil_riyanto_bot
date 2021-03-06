using Telegram.Bot.Types;

namespace Telegram.Bot.Fadhil_riyanto_bot.Commands
{
    class Getadmin
    {
        public static async Task<Message> Entry_point(ITelegramBotClient bot, Message msg)
        {
            List<string> adm_parse = new List<string>();
            string owner = await getowner(bot, msg);
            string[] admin = await getadmin(bot, msg);
            for(int i=0; i < admin.Length; i++){
                if(i == admin.Length - 1){
                    adm_parse.Add($"└ {admin[i]}");
                }else{
                    adm_parse.Add($"├ {admin[i]}");
                }
            }
            string text = $"Owner:\n{owner}\n\nAdmin:\n{String.Join("\n", adm_parse)}";
            return await bot.SendTextMessageAsync(chatId: msg.Chat.Id, text: text, replyToMessageId: msg.MessageId, parseMode: Types.Enums.ParseMode.Html);
        }
        protected static async Task<string[]> getadmin(ITelegramBotClient Bot, Message msg)
        {
            List<string> adminName = new List<string>();
            ChatMember[] list_yang_admin = await Bot.GetChatAdministratorsAsync(chatId: msg.Chat.Id);
            foreach (var listadmins in list_yang_admin)
            {
                if (listadmins.GetType() == typeof(Telegram.Bot.Types.ChatMemberAdministrator))
                {
                    adminName.Add($"<a href=\"tg://user?id={listadmins.User.Id}\">{listadmins.User.FirstName}</a>");
                }
            }
            return adminName.ToArray();
        }

        protected static async Task<string> getowner(ITelegramBotClient Bot, Message msg)
        {
            string? adminName = "tidak diketahui";
            ChatMember[] list_yang_admin = await Bot.GetChatAdministratorsAsync(chatId: msg.Chat.Id);
            foreach (var listadmins in list_yang_admin)
            {
                if (listadmins.GetType() == typeof(Telegram.Bot.Types.ChatMemberOwner))
                {
                    adminName = $"<a href=\"tg://user?id={listadmins.User.Id}\">{listadmins.User.FirstName}</a>";
                }
            }
            return adminName;
        }
    }
}

