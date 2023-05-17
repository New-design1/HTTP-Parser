using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace HTTP
{
    internal class Request
    {
       static HttpClient httpClient;
       
       public Request() 
        { 
            httpClient = new HttpClient();
        }
        
        public async Task<Rootobject?> GetPage(int pageNumber)
        {
            try
            {
                var s = System.Text.Json.JsonSerializer.Serialize(new Rootobj(pageNumber));
                using StringContent httpContent = new StringContent(s);
                using HttpRequestMessage? request = new HttpRequestMessage(HttpMethod.Post, "https://www.lesegais.ru/open-area/graphql");
                request.Content = httpContent;
                request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 YaBrowser/23.3.3.721 Yowser/2.5 Safari/537.36");
                using var response = await httpClient.SendAsync(request);
                var responsContent = await response.Content.ReadFromJsonAsync<Rootobject>();
                return responsContent;
                //foreach (var respon in responsContent.data.searchReportWoodDeal.content)
                //Console.WriteLine($"{respon.dealNumber} {respon.sellerName} {respon.sellerInn} {respon.buyerName} {respon.buyerInn} {respon.dealDate} {respon.woodVolumeSeller}/{respon.woodVolumeBuyer}");
                
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                return null;
            }
            
            
        }

        public async Task GetPageCount()
        {
            try
            {
                //using HttpClient httpClient = new HttpClient();
                using StringContent httpContent = new StringContent("{\"query\":\"query SearchReportWoodDeal($size: Int!, $number: Int!, $filter: Filter, $orders: [Order!]) {\\n  searchReportWoodDeal(filter: $filter, pageable: {number: $number, size: $size}, orders: $orders) {\\n    content {\\n      sellerName\\n      sellerInn\\n      buyerName\\n      buyerInn\\n      woodVolumeBuyer\\n      woodVolumeSeller\\n      dealDate\\n      dealNumber\\n      __typename\\n    }\\n    __typename\\n  }\\n}\\n\",\"variables\":{\"size\":20,\"number\":0,\"filter\":null,\"orders\":null},\"operationName\":\"SearchReportWoodDeal\"}");

                using HttpRequestMessage? request = new HttpRequestMessage(HttpMethod.Post, "https://www.lesegais.ru/open-area/graphql");
                request.Content = httpContent;
                request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 YaBrowser/23.3.3.721 Yowser/2.5 Safari/537.36");
                using var response = await httpClient.SendAsync(request);
                var responsContent = await response.Content.ReadFromJsonAsync<Rootobject>();
                foreach (var respon in responsContent.data.searchReportWoodDeal.content)
                    Console.WriteLine($"{respon.sellerName} {respon.sellerInn} {respon.buyerName} {respon.buyerInn} {respon.woodVolumeBuyer} {respon.woodVolumeSeller} {respon.dealDate} {respon.dealNumber} {respon.__typename}");
                Console.WriteLine(responsContent);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
