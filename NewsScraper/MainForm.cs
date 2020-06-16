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
            var newsList = DaumScraping.EconomicScrapProcessFromDaum(20);

            GetKeywords();

            var result = new List<News>();

            foreach (var keyword in _keywords)
            {
                result.AddRange(newsList.Where(x => x.Title.Contains(keyword)).ToList());
            }


            Console.WriteLine("------- 호재 뉴스 ----------");
            foreach (var data in result)
            {
                Console.WriteLine("{0}, {1}", data.Url, data.Title);
            }
        }

        private void GetKeywords()
        {
            _keywords.AddRange(new string[] { "유상증자", "유상 증자", "합병", "M&A", "계약채결", "계약 채결", "임상", "유증", "삼성전자", "중국", "수출계약", "수출 계약", "납품", "납품계약", "납품 계약", "신약", "수혜", "기대감", "통과"});
        }
    }
}
