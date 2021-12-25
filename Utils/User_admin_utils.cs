
using System.Diagnostics;
using Telegram.Bot.Types;

namespace Telegram.Bot.Fadhil_riyanto_bot.Utils{
    class UAdmin_utils{
        private Message message;
        private ITelegramBotClient bot;
        public UAdmin_utils(Message msg, ITelegramBotClient Bot) =>
            (
                message, 
                bot
            ) = (msg, Bot); 

        public async Task is_admin()
        {
            ChatMember[] list_yang_admin = await bot.GetChatAdministratorsAsync(chatId: message.Chat.Id);
            foreach(var listadmins in list_yang_admin){
                if(listadmins.GetType() == typeof(Telegram.Bot.Types.ChatMemberAdministrator))
                {
                    Console.WriteLine(listadmins.User);
                }else{
                    Console.WriteLine(listadmins.User);
                }
                
            }
            //Console.WriteLine(Debug_.print_r(list_yang_admin));
            //Console.WriteLine()
            // return true;
        }
    }
}