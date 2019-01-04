using System;
using System.Collections.Generic;

namespace TeltIt.BSG.DataModel
{
    public class Book : Item
    {
        public List<Author> Authors { get; }
        public string IBAN { get; set; }
        public Format Format { get; set; }
        public Cover Cover { get; set; }
        public int Size { get; set; }
        public string Publisher { get; set; }
        public int PublishingYear { get; set; }


        public Book()
        {
            Authors = new List<Author>();
        }
    }
}
