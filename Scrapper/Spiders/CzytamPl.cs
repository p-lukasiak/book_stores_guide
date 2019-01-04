using IronWebScraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeltIt.BSG.Scrapper.Readers;

namespace TeltIt.BSG.Scrapper.Spiders
{
    class CzytamPl : WebScraper
    {
        public override void Init()
        {
            this.LoggingLevel = WebScraper.LogLevel.All;

            // Read the sitemap (currently known 15 pages)
            HashSet<string> urls = new HashSet<string>();
            for (int i = 1; i <= 1; i++)
            {
                //urls.UnionWith(SitemapReader.ReadFromLoc(String.Format("https://czytam.pl/sitemap/mapa{0}.xml", i)));
            }

            // Parse each page find in the sitemap
            //foreach (string pageUrl in urls)
            //    this.Request(pageUrl, Parse);
            this.Request("https://czytam.pl/k,ks_777344,Porozmawiajmy-jak-dorosli-Warufakis-Janis.html", Parse);
            this.Request("https://czytam.pl/k,ks_619022,Post-Daniela-Dajka-Krystyna-Piorkowski-Lukasz.html", Parse);
        }

        public override void Parse(Response response)
        {
            // follow links to lists pages
            foreach (var list_link in response.Css("li.header-nav-list div div ul li a"))
            {
                this.Request(list_link.Attributes["href"], ParseList);
            }
        }

        private void ParseList(Response response)
        {
            // follow links to items pages
            foreach (var product in response.Css("div.product-info h3 a"))
            {
                this.Request(product.Attributes["href"], ParseProduct);
            }

            // @TODO: add pagination
        }

        private void ParseProduct(Response response)
        {
            var divProduct = response.Css("div.productreader");

            var title = divProduct.CSS("div.show-for-medium-up h1")[0].TextContentClean;
            Scrape(new ScrapedData() { { "Title", title } });
        }
    }
}
