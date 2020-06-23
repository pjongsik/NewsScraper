using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewsScraper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        List<string> _keywords = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            SearchNews();
        }

        public void SearchNews(int page = 20)
        {
            var newsList = DaumScraping.EconomicScrapProcessFromDaum(page);

            GetKeywords();

            var result = new List<News>();

            foreach (var keyword in _keywords)
            {
                result.AddRange(newsList.Where(x => x.Title.Contains(keyword)).ToList());
            }


            Console.WriteLine("------- 호재 뉴스 ---------");
            string searchTime = DateTime.Now.ToString("HH:mm:dd");
            TelegramHelper.SendMessageByTelegramBot(string.Format("-- {0} -- 뉴스 시작 -- ", searchTime));
            foreach (var data in result)
            {
                Console.WriteLine("{0}, {1}", data.Url, data.Title);

                TelegramHelper.SendMessageByTelegramBot(string.Format("{0} : {1} [{2}] ☞ {3}", data.Title, data.From, data.Time, data.Url));
            }

            TelegramHelper.SendMessageByTelegramBot(string.Format("-- {0} -- 종료 -- ", searchTime));
        }


        private void GetKeywords()
        {
            _keywords.AddRange(new string[] { "유상증자", "유상 증자", "증자", "합병", "M&A", "계약채결", "계약 채결", "임상", "유증", "삼성전자", "중국", "수출계약", "수출 계약", "납품", "납품계약", "납품 계약", "신약", "수혜", "기대감", "통과", "상승"});
        }
    }
}
