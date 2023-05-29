using HttpParser.JsonObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpParser.OutputMethods
{
    internal static class OutputToConsole
    {
        public static void WriteToConsole(PageResponse rootobject)
        {
            foreach (var content in rootobject.data.searchReportWoodDeal.content)
                Console.WriteLine($"{content.dealNumber} {content.sellerName} {content.sellerInn} {content.buyerName} {content.buyerInn} " +
                    $"{content.dealDate} {content.woodVolumeSeller}/{content.woodVolumeBuyer}");
        }
    }
}
