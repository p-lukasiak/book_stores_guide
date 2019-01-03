using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TurnerSoftware.SitemapTools;

namespace testApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var siteMapQuery = new SitemapQuery();
            var wholeSitemap = siteMapQuery.RetrieveSitemap("https://www.taniaksiazka.pl/images/Sitemap/Wszystkieprodukty.xml.gz");

            List<string> urls = new List<string>();
            /*foreach(var sitemap in wholeSitemap.Sitemaps)
                foreach (var url in sitemap.Urls)
                    urls.Add(url.Location.AbsolutePath);*/
            HashSet<string> uniqueUrl = new HashSet<string>(urls);
            /*Console.WriteLine("Tania ksiazka: " + urls.Count);

            wholeSitemap = siteMapQuery.RetrieveSitemap("https://www.nieprzeczytane.pl/sitemaps.xml");
            urls.Clear();
            foreach (var sitemap in wholeSitemap.Sitemaps)
                foreach (var url in sitemap.Urls)
                    urls.Add(url.Location.AbsolutePath);
            uniqueUrl = new HashSet<string>(urls);
            Console.WriteLine("Nieprzeczytane: " + urls.Count);*/

            /*urls.Clear();
            for (int i = 1; i <= 15; i++)
            {
                wholeSitemap = siteMapQuery.RetrieveSitemap(String.Format("https://czytam.pl/sitemap/mapa{0}.xml", i));
                foreach (var url in wholeSitemap.Urls)
                    urls.Add(url.Location.AbsolutePath);
            }
            uniqueUrl = new HashSet<string>(urls);
            Console.WriteLine("Czytam: " + urls.Count);
            */
            uniqueUrl.Add("a");
            uniqueUrl.Add("a");

            Console.WriteLine(uniqueUrl.Count);
            //System.Net.WebClient webClient = new System.Net.WebClient();
            //webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko)");
            //webClient.DownloadFile("http://static.prsa.pl/a3e26a9b-265d-444e-b1ff-ba0b4c8f2a71.mp3", "test.mp3");
            //webClient.DownloadFileAsync(new Uri("https://static.prsa.pl/a3e26a9b-265d-444e-b1ff-ba0b4c8f2a71.mp3"), "test.mp3");
            //var data = webClient.DownloadData("https://static.prsa.pl/a3e26a9b-265d-444e-b1ff-ba0b4c8f2a71.mp3");
            Console.ReadKey();
        }

        
    }
}
