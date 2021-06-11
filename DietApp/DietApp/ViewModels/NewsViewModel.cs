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

namespace DietApp.ViewModels
{
    public class NewsViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }


        private const string RSS_link = "https://www.runtastic.com/blog/en/tag/recipes/feed/";
        private const string RSS_to_json = "https://api.rss2json.com/v1/api.json?rss_url=";

        NewsRssObject rssObject;

        public NewsViewModel()
        {
            LoadData();
        }


        private void LoadData()
        {
            //StringBuilder strBuilder = new StringBuilder(RSS_to_json);
            //strBuilder.Append(RSS_link);

            //new LoadDataAsync(this).Execute();


            try
            {
                //var document = XDocument.Load("https://www.runtastic.com/blog/en/tag/recipes/feed/");
                //Console.WriteLine(document.ToString());

                WebClient client = new WebClient();
                string reply = client.DownloadString("https://www.runtastic.com/blog/en/tag/recipes/feed/");

                Console.WriteLine(reply);
            }
            catch { } // TODO: Deal with unavailable resource.





        }
    }
}
