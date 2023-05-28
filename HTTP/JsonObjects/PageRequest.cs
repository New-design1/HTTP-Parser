using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HttpParser.JsonObjects
{


    public class PageRequest
    {
        public string query { get; set; }
        public string operationName { get; set; }
        public PageVariables variables { get; set; }

        public PageRequest(int variablesNumber)
        {
            query = @"query SearchReportWoodDeal($size: Int!, $number: Int!, $filter: Filter, $orders: [Order!]) {
  searchReportWoodDeal(filter: $filter, pageable: {number: $number, size: $size}, orders: $orders) {
    content {
      sellerName
      sellerInn
      buyerName
      buyerInn
      woodVolumeBuyer
      woodVolumeSeller
      dealDate
      dealNumber
      __typename
    }
    __typename
  }
}
";

            operationName = "SearchReportWoodDeal";
            variables = new PageVariables()
            {
                size = 20,
                number = variablesNumber,
                filter = null,
                orders = null
            };
        }
    }

    public class PageVariables
    {
        public int size { get; set; }
        public int number { get; set; }
        public object? filter { get; set; }

        public object? orders { get; set; }
    }

}
