using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsScraper
{
    class DaumScraping
    {
        /// <summary>
        ///   //HTML
        //  < strong class="tit_thumb">
        //        <a href = "https://v.daum.net/v/20200612174202121" class="link_txt">고용보험 확대·한국판 뉴딜..내년 예산 550조 넘을듯</a>
        //        <span class="info_news">매일경제<span class="txt_bar"> · </span><span class="info_time">17:42</span></span>
        //    </strong>
        /// </summary>
        /// <returns></returns>
        public static List<News> EconomicScrapProcessFromDaum(int pageCount = 1)
        {
            List<News> news = new List<News>();

            int page = 1;

            string filter1 = "<strong class=\"tit_thumb\">";
            string filter2 = "<a href=\"";
            string filter2_1 = "\"";

            string filter3 = "class=\"link_txt\">";
            string filter3_1 = "</a>";

            string filter5 = "class=\"info_news\">";
            string filter5_1 = "<span class=\"txt_bar\"";

            string filter6 = "class=\"info_time\">";
            string filter6_1 = "</span>";

            while (page <= pageCount)
            {
                Console.WriteLine("page : {0}", page);

                string url = string.Format("https://news.daum.net/breakingnews/economic?page={0}", page);
                string text = Scraping.Scrap(url, Method.GET, null);
                while (text.IndexOf(filter1) > 0)
                {
                    text = text.Substring(text.IndexOf(filter1) + filter1.Length);
                    text = text.Substring(text.IndexOf(filter2) + filter2.Length);

                    //
                    string clickUrl = text.Substring(0, text.IndexOf(filter2_1));

                    text = text.Substring(text.IndexOf(filter3) + filter3.Length);

                    string title = text.Substring(0, text.IndexOf(filter3_1));

                    // 출처, 시간이 없으면 pass~
                    if (text.IndexOf(filter5) < 0 || text.IndexOf(filter6) < 0)
                        continue;

                    text = text.Substring(text.IndexOf(filter5) + filter5.Length);

                    string from = text.Substring(0, text.IndexOf(filter5_1));

                    text = text.Substring(text.IndexOf(filter6) + filter6.Length);

                    string time = text.Substring(0, text.IndexOf(filter6_1));

                    news.Add(new News(title, clickUrl, from, time));

                    Console.WriteLine("{0}", title);
                    Console.WriteLine("{0} - from : {1}, [{2}]", clickUrl, from, time);
                }

                page++;
            }

            return news;
        }
    }
}
