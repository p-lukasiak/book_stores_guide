using System;
using System.Collections.Generic;
using System.Text;

namespace TeltIt.BSG.DataModel
{
    public enum ItemType
    {
        BOOK
    }

    public class Item
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public List<string> Categories { get; }
        public string Description { get; set; }
        public string OriginalTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Author> Authors { get; }
        public string IBAN { get; set; }
        public Format Format { get; set; }
        public Cover Cover { get; set; }
        public int Size { get; set; }
        public string Publisher { get; set; }
        public int PublishingYear { get; set; }
        public Site Site { get; set; }
        public decimal Price { get; set; }
        public Shipment Shipment { get; set; }

        public Item()
        {
            Categories = new List<string>();
            Authors = new List<Author>();
        }
    }
}
