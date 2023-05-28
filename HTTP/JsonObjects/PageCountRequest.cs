using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HttpParser.JsonObjects
{
    internal class PageCountRequest
    {
        public string query { get; set; }
        public PageCountVariables variables { get; set; }
        public string operationName { get; set; }

        public PageCountRequest() 
        {
            operationName = "SearchReportWoodDealCount";
            query = @"query SearchReportWoodDealCount($size: Int!, $number: Int!, $filter: Filter, $orders: [Order!]) {
                searchReportWoodDeal(filter: $filter, pageable: { number: $number, size: $size}, orders: $orders) {
                    total
                    number
                  size
    overallBuyerVolume
                  overallSellerVolume
    __typename
                }
            }";

            variables = new PageCountVariables()
            {
                filter = null,
                number = 0,
                size = 20
            };

        }
    }

    public class PageCountVariables
    {
        public int size { get; set; }
        public int number { get; set; }
        public object? filter { get; set; }
    }


}

