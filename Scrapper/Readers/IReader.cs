using IronWebScraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeltIt.BSG.DataModel;

namespace TeltIt.BSG.Scrapper.Readers
{
    public abstract class IReader
    {
        public Response Response { get; set; }

        protected abstract ItemType DetermineItemType();
        protected abstract void ReadCategory(Item item);
        protected abstract void ReadDetails(Item item);
        public abstract Item ReadItem();
    }
}
