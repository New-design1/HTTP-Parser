using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpParser.JsonObjects;
using Microsoft.EntityFrameworkCore;

namespace HttpParser.OutputMethods
{
    public static class OutputToDB
    {
        public static void WriteToDB(PageResponse page)
        {
            using (ApplicationContext db = new ApplicationContext()) 
            { 
                foreach (var content in page.data.searchReportWoodDeal.content)
                {
                    DealWithWood deal = new DealWithWood()
                    {
                        DealWithWoodId = content.dealNumber,
                        SellerName = content.sellerName,
                        SellerInn = content.sellerInn,
                        BuyerName = content.buyerName,
                        BuyerInn= content.buyerInn,
                        WoodVolumeSeller = content.woodVolumeSeller,
                        WoodVolumeBuyer= content.woodVolumeBuyer,
                        DealDate= content.dealDate
                    };
                    db.DealsWithWood.Add(deal);
                }
                db.SaveChanges();
            }
            Console.WriteLine("Данные успешно сохранены");
        }
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<DealWithWood> DealsWithWood => Set<DealWithWood>();

        public ApplicationContext() => Database.EnsureCreated();
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@$"Data Source={Environment.CurrentDirectory}\OutputFile.db");
        }
    }

    public class DealWithWood
    {
        public string DealWithWoodId { get; set; }
        public string SellerName { get; set; }
        public string SellerInn { get; set; }
        public string BuyerName { get; set; }
        public string BuyerInn { get; set; }
        public float WoodVolumeSeller { get; set; }
        public float WoodVolumeBuyer { get; set; }
        public string DealDate { get; set; }

    }

}
