using CsvHelper.Configuration;
using EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataImporter.Models
{
    public class MapStringKeywordDaily: ClassMap<StringKeywordDaily>
    {
        public MapStringKeywordDaily()
        {
            Map(m => m.Date).Index(0);
            Map(m => m.CampaignName).Index(3);
            Map(m => m.AdGroupName).Index(4);
            Map(m => m.Keyword).Index(7);
            Map(m => m.Impressions).Index(8);
            Map(m => m.Clicks).Index(9);
            Map(m => m.Spend).Index(12);
            Map(m => m.Days7TotalSales).Index(13);
            Map(m => m.Days7TotalOrders).Index(16);
            Map(m => m.Days7TotalUnits).Index(17);
            Map(m => m.Days7ConversionRate).Index(18);
            Map(m => m.Days7SameSkuUnits).Index(19);
            Map(m => m.Days7OtherSkuUnits).Index(20);
            Map(m => m.Days7SameSkuSale).Index(21);
            Map(m => m.Days7OtherSkuSale).Index(22);
        }
    }
}
