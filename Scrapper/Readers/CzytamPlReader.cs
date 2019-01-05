using IronWebScraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeltIt.BSG.DataModel;

namespace TeltIt.BSG.Scrapper.Readers
{
    class CzytamPlReader : IReader
    {
        public static Site CurrentSite = new Site(SiteInstance.CZYTAM, "czytam.pl", "https://czytam.pl");

        public override Item ReadItem()
        {
            var item = new Item()
            {
                Site = CurrentSite
            };

            // Read the categories
            ReadCategory(item);

            // Read details
            ReadDetails(item);

            return item;
        }

        protected override ItemType DetermineItemType()
        {
            // Retrieve the name of the category
            var divCategoryPath = Response.Css("div#breadcrumb");
            var liCategoryPath = divCategoryPath.CSS("div>ul>li")[1];
            var category = liCategoryPath.Css("a span")[0].InnerText;

            switch (category)
            {
                case "Książki":
                    return ItemType.BOOK;
                default:
                    throw new Exception();
            }

        }

        protected override void ReadCategory(Item item)
        {
            string categoryPath = "";
            string categorySeparator = "->";

            // Retrieve the category path
            var divCategoryPath = Response.Css("div#breadcrumb");
            var liCategoryPath = divCategoryPath.CSS("div>ul>li");
            for (int i = 1; i < (liCategoryPath.Length - 1); i++)
                categoryPath += liCategoryPath[i].Css("a>span")[0].InnerText + categorySeparator;
            string[] categorySeparators = new string[] { categorySeparator };
            item.Categories.AddRange(categoryPath.Split(categorySeparators, StringSplitOptions.RemoveEmptyEntries));
        }

        protected override void ReadDetails(Item item)
        {
            // Details from top of the page
            ReadDetailsFromTop(item);

            // Read description
            ReadDescription(item);
        }

        private void ReadDetailsFromTop(Item item)
        {
            var node = Response.Css("div#main>div>div")[2];
            
            // Retrieve title
            var nodeTitle = node.Css("div>h1")[0];
            item.Title = nodeTitle.ChildNodes[0].InnerTextClean;

            // Subtitle
            var nodeSubtitle = nodeTitle.Css("i");
            if (nodeSubtitle.Length > 0)
                item.Subtitle = nodeSubtitle[0].InnerTextClean;

            // Authors
            var nodeAuthors = node.Css("div>h2>a");
            foreach (var authorNode in nodeAuthors)
                item.Authors.Add(new Author(authorNode.InnerTextClean));

            // Price
            var nodePrice = node.Css("div.price>strong")[0];
            var nodeShipment = node.Css("div.wysylka>strong")[0];
            item.Price = Decimal.Parse(nodePrice.ChildNodes[0].InnerTextClean);
            item.Shipment = ReadShipment(nodeShipment.InnerTextClean);
            
        }

        private Shipment ReadShipment(string shipment)
        {
            var shipmentDetails = new Shipment()
            {
                ShipmentType = ShipmentType.NOT_AVAILABLE
            };

            return shipmentDetails;
        }

        private void ReadDescription(Item item)
        {
            var nodeDescription = Response.Css("div#opis")[0];
            item.Description = nodeDescription.Css("p>span")[0].InnerTextClean;
        }
    }
}
