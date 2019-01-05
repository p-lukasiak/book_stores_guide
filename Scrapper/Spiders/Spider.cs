using IronWebScraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeltIt.BSG.Scrapper.Readers;

namespace TeltIt.BSG.Scrapper.Spiders
{
    public abstract class Spider : WebScraper
    {
        protected IReader reader;
    }
}
