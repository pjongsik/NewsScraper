using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsScraper
{
    public class News
    {
        public News() { }
        public News(string title, string url, string from = null, string time = null)
        {
            Title = title;
            Url = url;
            From = from;
            Time = time;
        }

        public string Title { get; set; }
        public string Url { get; set; }
        public string From { get; set; }
        public string Time { get; set; }

    }
}
