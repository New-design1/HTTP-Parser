using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpParser.JsonObjects
{
    internal class PageCountResponse
    {
        public PageCountData data { get; set; }
        
        public class PageCountData
        {
            public Searchreportwooddeal searchReportWoodDeal { get; set; }
        }

        public class Searchreportwooddeal
        {
            public int total { get; set; }
            public int number { get; set; }
            public int size { get; set; }
            public float overallBuyerVolume { get; set; }
            public float overallSellerVolume { get; set; }
            public string __typename { get; set; }
        }

    }
}
