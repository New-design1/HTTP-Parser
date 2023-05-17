using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using Newtonsoft.Json;
using HttpParser;

namespace HTTP
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            
            Request request =  new Request();
            Rootobject? response =  await request.GetPage(0);
            OutputMethod output = new OutputMethod(response);
            output.CreateFile();
           // Console.WriteLine("Нажмите чтобы продолжить");
           // request.GetPage(1);
            Console.ReadKey();
            
        }
       
    }
}