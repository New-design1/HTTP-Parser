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
            
           // Console.WriteLine("Нажмите чтобы продолжить");
            request.GetPage(1);
            Console.ReadKey();
            
        }
       
    }
}