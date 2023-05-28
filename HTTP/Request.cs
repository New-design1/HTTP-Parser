using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HttpParser.JsonObjects;
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
        
        public async Task<PageResponse?> GetPage(int pageNumber)
        {
            try
            {
                string content = System.Text.Json.JsonSerializer.Serialize(new PageRequest(pageNumber));
                using StringContent httpContent = new StringContent(content);
                using HttpRequestMessage? request = new HttpRequestMessage(HttpMethod.Post, "https://www.lesegais.ru/open-area/graphql");
                request.Content = httpContent;
                request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 YaBrowser/23.3.3.721 Yowser/2.5 Safari/537.36");
                using var response = await httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadFromJsonAsync<PageResponse>();
                return responseContent;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                return null;
            }
            
            
        }

        public async Task<int?> GetPageCount()
        {
            try
            {
                string content = System.Text.Json.JsonSerializer.Serialize(new PageCountRequest());
                using StringContent httpContent = new StringContent(content);
                using HttpRequestMessage? request = new HttpRequestMessage(HttpMethod.Post, "https://www.lesegais.ru/open-area/graphql");
                request.Content = httpContent;
                request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 YaBrowser/23.3.3.721 Yowser/2.5 Safari/537.36");
                using var response = await httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadFromJsonAsync<PageCountResponse>();
                int? pageCount = responseContent?.data.searchReportWoodDeal.total / 20;
                return responseContent?.data.searchReportWoodDeal.total % 20 != 0 ? pageCount + 1 : pageCount;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
