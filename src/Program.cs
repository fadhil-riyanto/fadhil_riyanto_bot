using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;

namespace Telegram.Bot.Fadhil_riyanto_bot
{
    public static class fadhil_riyanto_bot
    {
        private static TelegramBotClient? Bot;
        public static async Task Main()
        {
            TelegramBotClient Bot = new TelegramBotClient(konfigurasi.token_bot);
            User saya = await Bot.GetMeAsync();
            Console.Title = "Fadhil Riyanto Bot";

            using var stop_bot = new CancellationTokenSource();

            ReceiverOptions receiver_req = new() { AllowedUpdates = { } };
            Bot.StartReceiving(Handlers.HandleUpdateAsync,
                               Handlers.HandleErrorAsync,
                               receiver_req,
                               stop_bot.Token);

            Console.WriteLine($"Bot Berjalan : @{saya.Username}");
            Console.ReadLine();

            // Send cancellation request to stop bot
            stop_bot.Cancel();

        }
    }
}