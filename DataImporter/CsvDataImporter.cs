using CsvHelper;
using DataImporter.Models;
using EF.Models;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace DataImporter
{
    public class CsvDataImporter
    {
        private string _dbConnString = "Server=127.0.0.1;Port=5432;Database=myprimeads;Username=postgres;Password=pgMadMag"; // TODO: Pull from setting file
        private EF.Data.MyprimeadsContext _dbContext = null;

        public CsvDataImporter()
        {
            DbContextOptionsBuilder<EF.Data.MyprimeadsContext> dbCntxOptsBuilder = new DbContextOptionsBuilder<EF.Data.MyprimeadsContext>();
            var dbCnxOptions = dbCntxOptsBuilder.UseNpgsql(_dbConnString).Options;
            _dbContext = new EF.Data.MyprimeadsContext(dbCnxOptions);
        }

        public List<ImportReportKeywordDaily> ImportSponsoredProductsSearchTermsDaily(string csvPath)
        {
            List<ImportReportKeywordDaily> data = ParseSponsoredProductsSearchTermsDaily(csvPath);

            foreach(var item in data)
            {
                var existingItem = _dbContext.ImportReportKeywordDaily.FirstOrDefault(i => i.Date == item.Date &&
                    i.AdGroupName == item.AdGroupName && i.CampaignName == item.CampaignName && i.Keyword == item.Keyword);
                if (existingItem != null)
                {
                    item.Id = existingItem.Id;
                    item.Adapt(existingItem);
                }
                else
                {
                    _dbContext.ImportReportKeywordDaily.Add(item);
                }
            }

            _dbContext.SaveChanges();

            return data;
        }

        public IEnumerable<T> SimpleParseRecords<T>(string csvPath)
        {
            using StreamReader reader = new StreamReader(csvPath);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            IEnumerable<T> records = csvReader.GetRecords<T>();
            return records;
        }

        public List<ImportReportKeywordDaily> ParseSponsoredProductsSearchTermsDaily(string csvPath)
        {
            List<ImportReportKeywordDaily> data = new List<ImportReportKeywordDaily>();
            using StreamReader reader = new StreamReader(csvPath);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            csvReader.Configuration.HasHeaderRecord = true;
            csvReader.Configuration.RegisterClassMap<MapStringKeywordDaily>();
            List<StringKeywordDaily> records = csvReader.GetRecords<StringKeywordDaily>().ToList();

            foreach(StringKeywordDaily r in records)
            {
                ImportReportKeywordDaily item = new ImportReportKeywordDaily() {
                    Date = DateTime.ParseExact(r.Date, "MMM dd, yyyy", CultureInfo.InvariantCulture),
                    AdGroupName = r.AdGroupName,
                    CampaignName = r.CampaignName, 
                    Clicks = r.Clicks,
                    Days7ConversionRate = ParseStringToDecimal(r.Days7ConversionRate),
                    Days7OtherSkuSale = ParseStringToDecimal(r.Days7OtherSkuSale),
                    Days7OtherSkuUnits = r.Days7OtherSkuUnits,
                    Days7SameSkuSale = ParseStringToDecimal(r.Days7SameSkuSale), 
                    Days7SameSkuUnits = r.Days7SameSkuUnits, 
                    Days7TotalOrders = r.Days7TotalOrders,
                    Days7TotalSales = ParseStringToDecimal(r.Days7TotalSales), 
                    Days7TotalUnits = r.Days7TotalUnits, 
                    Impressions = r.Impressions, 
                    Keyword = r.Keyword, 
                    Spend = ParseStringToDecimal(r.Spend)
                };
                data.Add(item);
            }

            return data;
        }

        private decimal ParseStringToDecimal(string val)
        {
            val = val.Replace("$", "");
            val = val.Replace("%", "");
            decimal dVal = decimal.Parse(val);
            return dVal;
        }
    }
}
