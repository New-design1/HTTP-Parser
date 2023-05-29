using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using Newtonsoft.Json;
using HttpParser.OutputMethods;
using System.Text.RegularExpressions;
using System.IO;

namespace HTTP
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            
            Request request =  new Request();
            var pageCount =  await request.GetPageCount();

            Regex regexNumber = new Regex(@"^\d*$");
            Regex regexRange = new Regex(@"^\d*-\d*$");

            List<int> pages;

            Console.WriteLine($"Всего {pageCount.ToString()} страниц. Введите номер страницы или диапазон страниц. Например: 10 или 1-20");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == null) Console.WriteLine("Ошибка. Пустая строка.");
                if(regexNumber.Match(input).Value == input) 
                {
                    pages = input.Split().Select(x => Convert.ToInt32(x)).ToList();
                    if (pages[0] > pageCount || pages[0] < 1) 
                    {
                        Console.WriteLine($"Допустимый выбор страниц от 1 до {pageCount.ToString()}");
                        continue;
                    }
                    break;
                } 
                if(regexRange.Match(input).Value == input) 
                { 
                    pages = input.Split("-").Select(x => Convert.ToInt32(x)).ToList();
                    if (pages[0] > pageCount || pages[0] < 1 || pages[1] > pageCount || pages[1] < 1)
                    {
                        Console.WriteLine($"Допустимый выбор страниц от 1 до {pageCount.ToString()}");
                        continue;
                    }
                    break;
                }
                Console.WriteLine("Неверный формат ввода");
            }

            Console.WriteLine("Выберите способ вывода. \n1 - Вывод на консоль \n2 - Вывод в файл \n3 - Вывод в бд");
            int outputMethod = Convert.ToInt32(Console.ReadLine());

            if (outputMethod == 1)
            {
                if(pages.Count == 1)
                {
                    var response = await request.GetPage(pages[0] - 1);
                    OutputToConsole.WriteToConsole(response);
                }
                if (pages.Count == 2)
                {
                    for (int i = pages[0] - 1; i <= pages[1] - 1; i++)
                    {
                        var response = await request.GetPage(i);
                        OutputToConsole.WriteToConsole(response);
                    }
                }
            }
            if (outputMethod == 2)
            {
                if (pages.Count == 1)
                {
                    var response = await request.GetPage(pages[0] - 1);

                    string path;
                    OutputToFile.CreateFile(out path);
                    OutputToFile.WriteToFile(response, path);
                }
                if (pages.Count == 2) 
                {
                    string path;
                    OutputToFile.CreateFile(out path);
                    
                    for (int i = pages[0] - 1; i <= pages[1] - 1; i++)
                    {
                        var response = await request.GetPage(i);
                        OutputToFile.WriteToFile(response, path);
                    }

                }
            }
            if(outputMethod == 3)
            {
                if (pages.Count == 1)
                {
                    Console.WriteLine("Файл OutputFile.db будте сохранен в текущей директории");
                    var response = await request.GetPage(pages[0] - 1);

                    OutputToDB.WriteToDB(response);
                }
                if(pages.Count == 2) 
                {
                    Console.WriteLine("Файл OutputFile.db будте сохранен в текущей директории");
                    for (int i = pages[0] - 1; i <= pages[1] - 1; i++)
                    {
                        var response = await request.GetPage(i);
                        OutputToDB.WriteToDB(response);
                    }
                }
            }

            Console.WriteLine("Нажмите любую клавишу, чтобы выйти");
            Console.ReadKey();
            
        }
       
    }
}