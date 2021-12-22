using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Fadhil_riyanto_bot.Commands;

namespace Telegram.Bot.Fadhil_riyanto_bot{
public class register_handler_command{
    public static string? text_plain, username;
    public static int? user_id;

    
    protected static async Task HandleInputanMessage(ITelegramBotClient botClient, Message message){
        var action = message.Text!.Split(' ')[0] switch
        {
            "/start"   => Telegram.Bot.Fadhil_riyanto_bot.Commands.Start.Entry_point(botClient, message),
            
            // "/keyboard" => SendReplyKeyboard(botClient, message),
            // "/remove"   => RemoveKeyboard(botClient, message),
            // "/photo"    => SendFile(botClient, message),
            // "/request"  => RequestContactAndLocation(botClient, message),
            _           => register_handler_command.CommandTidakDitemukan(botClient, message, new register_handler_command)
        };
        Message sentMessage = await action;
    }
    private static async Task<Message> CommandTidakDitemukan(ITelegramBotClient botClient, Message message, register_handler_command util){
        string usage = "Maaf, command tidak dapat dikenali, silahkan cek dengan /help";
        return await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: usage);
    }
    // protected static async Task HandleEditMessage(ITelegramBotClient botClient, Message message){
        
    // }
    // protected static async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery message){
        
    // }
    // protected static async Task HandleInlineQuery(ITelegramBotClient botClient, InlineQuery message){
        
    // }
}
}

