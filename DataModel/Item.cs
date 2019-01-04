using System;
using System.Collections.Generic;
using System.Text;

namespace TeltIt.BSG.DataModel
{
    public abstract class Item
    {
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<ItemInstance> Instances { get; }

        public Item()
        {
            Instances = new List<ItemInstance>();
        }
    }
}
