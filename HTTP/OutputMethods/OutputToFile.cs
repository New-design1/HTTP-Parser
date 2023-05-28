using HttpParser.JsonObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpParser.OutputMethods
{
    internal static class OutputToFile
    {
        public static void CreateFile(out string path)
        {
            try
            {
                Console.WriteLine(@"Введите путь, где будет сохранен OutputFile.txt. Пример пути: D:\AnyFolder\");
                path = Console.ReadLine() + "OutputFile.txt";
                File.Create(path).Dispose();
                
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                path = null;
            }
        }
        public static async void WriteToFile(PageResponse rootobject, string path)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(path, true);

                foreach (var content in rootobject.data.searchReportWoodDeal.content)
                    await writer.WriteLineAsync($"{content.dealNumber} {content.sellerName} {content.sellerInn} {content.buyerName} {content.buyerInn} " +
                        $"{content.dealDate} {content.woodVolumeSeller}/{content.woodVolumeBuyer}");
                Console.WriteLine("Данные успешно сохранены");
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message); 
            }
        }
    }
}
