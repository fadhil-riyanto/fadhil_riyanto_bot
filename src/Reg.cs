using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Fadhil_riyanto_bot.Commands;

namespace Telegram.Bot.Fadhil_riyanto_bot
{
    public class register_handler_command
    {
        public static string? text_plain, username;
        public static int? user_id;


        protected static async Task HandleInputanMessage(ITelegramBotClient botClient, Message message)
        {
            if (!konfigurasi.debug_mod)
            {
                var action = message.Text!.Split(' ')[0] switch
                {
                    "/start" => Telegram.Bot.Fadhil_riyanto_bot.Commands.Start.Entry_point(botClient, message),
                    "/debug" => Telegram.Bot.Fadhil_riyanto_bot.Commands.Debug.Entry_point(botClient, message),
                    "/getadmin" => Telegram.Bot.Fadhil_riyanto_bot.Commands.Getadmin.Entry_point(botClient, message),
                    "/xjson" => Telegram.Bot.Fadhil_riyanto_bot.Commands.Xjson.Entry_point(botClient, message),

                    // "/keyboard" => SendReplyKeyboard(botClient, message),
                    // "/remove"   => RemoveKeyboard(botClient, message),
                    // "/photo"    => SendFile(botClient, message),
                    // "/request"  => RequestContactAndLocation(botClient, message),
                    _ => register_handler_command.CommandTidakDitemukan(botClient, message)
                };
                Message sentMessage = await action;
            }
            else
            {
                Utils.Utils utils = new Telegram.Bot.Fadhil_riyanto_bot.Utils.Utils(message);
                if (!utils.is_grup())
                {
                    string text = "maaf, bot sedang dalam debugging, coba lagi nanti";
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: text, replyToMessageId: message.MessageId, parseMode: Types.Enums.ParseMode.Html);
                }


            }

        }
        private static async Task<Message> CommandTidakDitemukan(ITelegramBotClient botClient, Message message)
        {
            Utils.Utils utils = new Telegram.Bot.Fadhil_riyanto_bot.Utils.Utils(message);
            if (utils.is_grup() == false)
            {
                string usage = "maaf, command tidak ditemukan";
                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: usage);
            }
            else
            {
                string usage = "";
                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: usage);
            }
        }
        // protected static async Task HandleEditMessage(ITelegramBotClient botClient, Message message){

        // }
        // protected static async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery message){

        // }
        // protected static async Task HandleInlineQuery(ITelegramBotClient botClient, InlineQuery message){

        // }
    }
}

