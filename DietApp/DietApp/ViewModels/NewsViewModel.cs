using DietApp.Models;
using DietApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Xamarin.Forms;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System.ServiceModel.Syndication;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Collections.ObjectModel;


namespace DietApp.ViewModels
{
    public class NewsViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        readonly IList<NewsItem> source;

        public ObservableCollection<NewsItem> NewsItems { get; private set; }


        private string _NewsFeedBox;
        public string NewsFeedBox
        {
            get { return _NewsFeedBox; }
            set
            {
                _NewsFeedBox = value;
                OnPropertyChanged(nameof(NewsFeedBox)); // Notify that there was a change on this property
            }
        }

        
        //private const string RSS_link = "https://news.google.com/rss/search?q=zdrowe%20jedzenie&hl=pl&gl=PL&ceid=PL%3Apl";
        private const string RSS_link = "https://www.runtastic.com/blog/en/tag/recipes/feed/";
        private const string RSS_to_json = "https://api.rss2json.com/v1/api.json?rss_url=";

        NewsRssObject rssObject;
        NewsItem newsitem;

        public NewsViewModel()
        {
            source = new List<NewsItem>();
            LoadData();
        }


        private void LoadData()
        {
            
            StringBuilder url = new StringBuilder(RSS_to_json);
            url.Append(RSS_link);


            string xmlStr;
            using (var wc = new WebClient())
            {
                xmlStr = wc.DownloadString(RSS_to_json+RSS_link);
            }

            NewsRssObject json_rss = JsonConvert.DeserializeObject<NewsRssObject>(xmlStr);
            

           
            foreach (var newsitem in json_rss.items)
            {
                source.Add(new NewsItem
                {
                    title = newsitem.title,
                    pubDate = newsitem.pubDate,
                    description = newsitem.description,
                    thumbnail = newsitem.thumbnail
                });
                NewsFeedBox = newsitem.title;
            }
            
            NewsItems = new ObservableCollection<NewsItem>(source);
            


            //NewsFeedBox = json_rss.status;







        }




    }
}
