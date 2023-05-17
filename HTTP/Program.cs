using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using Newtonsoft.Json;

namespace HTTP
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Request request =  new Request();
            request.GetPage(0);
            Console.WriteLine("Нажмите чтобы продолжить");
            Console.ReadKey();
            
        }

        //static async void GetPage()
        //{
        //   // HttpClient httpClient = new Request().httpClient;
        //    using var request = new HttpRequestMessage(HttpMethod.Get, "https://www.lesegais.ru/open-area/");
        //    request.Headers.Add("User-Agent", " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 YaBrowser/23.3.3.721 Yowser/2.5 Safari/537.36");
            
        //    //using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://www.lesegais.ru/open-area/static");
        //    using var response = await httpClient.SendAsync(request);
        //    Console.WriteLine($"Status: {response.StatusCode}\n");
        //    //Console.WriteLine("Headers");
        //    //foreach (var header in response.Headers)
        //    //{
        //    //    Console.Write($"{header.Key}:");
        //    //    foreach (var headerValue in header.Value)
        //    //    {
        //    //        Console.WriteLine(headerValue);
        //    //    }
        //    //}
        //    //// содержимое ответа
        //    //Console.WriteLine("\nContent");
        //    Console.WriteLine(response);
        //    var content = await response.Content.ReadAsStringAsync();

        //    Console.WriteLine(content);
            
        //}

        //static async Task PostRequest()
        //{
        //    try
        //    {
        //        using HttpClient webClient = new HttpClient();
        //        using StringContent httpContent = new StringContent("{\"query\":\"query SearchReportWoodDeal($size: Int!, $number: Int!, $filter: Filter, $orders: [Order!]) {\\n  searchReportWoodDeal(filter: $filter, pageable: {number: $number, size: $size}, orders: $orders) {\\n    content {\\n      sellerName\\n      sellerInn\\n      buyerName\\n      buyerInn\\n      woodVolumeBuyer\\n      woodVolumeSeller\\n      dealDate\\n      dealNumber\\n      __typename\\n    }\\n    __typename\\n  }\\n}\\n\",\"variables\":{\"size\":20,\"number\":0,\"filter\":null,\"orders\":null},\"operationName\":\"SearchReportWoodDeal\"}");
            
        //        using var request = new HttpRequestMessage(HttpMethod.Post, "https://www.lesegais.ru/open-area/graphql");
        //        request.Content = httpContent;
        //        request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 YaBrowser/23.3.3.721 Yowser/2.5 Safari/537.36");
        //        using var response = await webClient.SendAsync(request);
        //        var responsContent = await response.Content.ReadFromJsonAsync<Rootobject>();
        //        foreach (var respon in responsContent.data.searchReportWoodDeal.content)
        //            Console.WriteLine($"{respon.sellerName} {respon.sellerInn} {respon.buyerName} {respon.buyerInn} {respon.woodVolumeBuyer} {respon.woodVolumeSeller} {respon.dealDate} {respon.dealNumber} {respon.__typename}");
        //        Console.WriteLine(responsContent);
        //    }
        //    catch (Exception ex) { Console.WriteLine(ex.Message); }
        //}
        
        
       
    }
}