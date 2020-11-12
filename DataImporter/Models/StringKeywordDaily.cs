using System;
using System.Collections.Generic;
using System.Text;

namespace DataImporter.Models
{
    public class StringKeywordDaily
    {
        public string Date { get; set; }
        public string CampaignName { get; set; }
        public string AdGroupName { get; set; }
        public string Keyword { get; set; }
        public int Clicks { get; set; }
        public int Impressions { get; set; }
        public string Spend { get; set; }
        public string Days7TotalSales { get; set; }
        public int Days7TotalOrders { get; set; }
        public int Days7TotalUnits { get; set; }
        public string Days7ConversionRate { get; set; }
        public int Days7SameSkuUnits { get; set; }
        public int Days7OtherSkuUnits { get; set; }
        public string Days7SameSkuSale { get; set; }
        public string Days7OtherSkuSale { get; set; }
    }
}
