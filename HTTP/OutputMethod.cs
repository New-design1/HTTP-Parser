using HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpParser
{
    internal class OutputMethod
    {
        public Rootobject rootobject { get; set; }
        public OutputMethod(Rootobject inputRootobject) 
        { 
            rootobject = inputRootobject;
        }

        public void WriteToConsole()
        {
            foreach (var content in rootobject.data.searchReportWoodDeal.content)
                Console.WriteLine($"{content.dealNumber} {content.sellerName} {content.sellerInn} {content.buyerName} {content.buyerInn} " +
                    $"{content.dealDate} {content.woodVolumeSeller}/{content.woodVolumeBuyer}");

        }

        public async void CreateFile()
        {
            try
            {
                Console.WriteLine(@"Введите путь, где будет сохранен file.txt. Пример пути: D:\AnyFolder\");
                string path = Console.ReadLine() + "file.txt";
                File.Create(path).Dispose();

                using StreamWriter writer = new StreamWriter(path, false);

                foreach (var content in rootobject.data.searchReportWoodDeal.content)
                    await writer.WriteLineAsync($"{content.dealNumber} {content.sellerName} {content.sellerInn} {content.buyerName} {content.buyerInn} " +
                        $"{content.dealDate} {content.woodVolumeSeller}/{content.woodVolumeBuyer}");
                Console.WriteLine("Данные успешно сохранены");
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }         
        }

       

    }
}
