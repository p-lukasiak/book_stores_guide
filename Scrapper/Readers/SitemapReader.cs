using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnerSoftware.SitemapTools;

namespace TeltIt.BSG.Scrapper.Readers
{
    class SitemapReader
    {
        public static HashSet<string> ReadFromLoc(string sitemapUrl)
        {
            var siteMapQuery = new SitemapQuery();
            var sitemap = siteMapQuery.RetrieveSitemap(sitemapUrl);

            // Read the sitemap and store unique urls in the HashSet
            HashSet<string> urls = new HashSet<string>();
            foreach (var url in sitemap.Urls)
                urls.Add(url.Location.AbsolutePath);

            return urls;
        }
    }
}
