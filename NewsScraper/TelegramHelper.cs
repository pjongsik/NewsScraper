using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NewsScraper
{
    class TelegramHelper
    {
        public static bool SendMessageByTelegramBot(string message)
        {
            bool result = true;
            try
            {
                // 주소 인코딩
                message = HttpUtility.UrlEncode(message);

                string url = "https://api.telegram.org/bot999783271:AAH-RWs1aqO1q0HmUrCKpJsrYLXgYM-uJrY/sendMessage?chat_id=1124104280&text={0}";
                url = string.Format(url, message);
                Scraping.Scrap(url, Method.GET, null);

            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
