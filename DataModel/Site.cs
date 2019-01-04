using System;
using System.Collections.Generic;

namespace TeltIt.BSG.DataModel
{
    public enum SiteInstance
    {
        CZYTAM,
        NIEPRZECZYTANE
    }

    public class Site
    {
        public SiteInstance Instance { get; }
        public string Name { get; }
        public string Url { get; }

        public Site(SiteInstance instance, string name, string url)
        {
            Instance = instance;
            Name = name;
            Url = url;
        }

        public static List<Site> Sites = new List<Site>()
        {
            new Site(SiteInstance.CZYTAM, "czytam.pl", "https://czytam.pl")
        };
    }
}
