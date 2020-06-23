using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NewsScraper
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0 && "sendMessage".Equals(args[0]))
            {
                int page = 20;
                if (args.Length > 1)
                    int.TryParse(args[1].ToString(), out page);

                var main = new MainForm();
                main.SearchNews(page);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
