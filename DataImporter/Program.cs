using System;

namespace DataImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CsvDataImporter csvDataImporter = new CsvDataImporter();
            var records = csvDataImporter.ImportSponsoredProductsSearchTermsDaily(@"D:\Lutter Projects\Data Files\Sponsored Products Search term Daily 30 days.csv");
        }
    }

}
