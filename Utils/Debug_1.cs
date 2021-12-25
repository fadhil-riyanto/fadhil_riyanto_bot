using System.Text;

namespace Telegram.Bot.Fadhil_riyanto_bot.Utils
{
    class Debugger
    {
        public static string print_r(Array arr)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (object o in arr)
            {
                stringBuilder.Append(o);
                stringBuilder.Append(", ");
            }

            return stringBuilder.ToString();

        }
    }
}