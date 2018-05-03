using System;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Encodings.Web;
using System.IO;
using OverViewConsoleApp.Services;
using StackExchange.Redis;
using OverViewConsoleApp.Config;
using WcfServices;
using System.ServiceModel;

namespace OverViewConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Logging.TestLogProvider();
            //ConfigurationTest.ConfigurationTestConfig();
            TestWcfService();
            Console.ReadLine();
        }


        static async void TestWcfService()
        {
            var client = new NameServiceClient(NameServiceClient.EndpointConfiguration.NameService);
            var message = await client.HelloAsync("tim");
            Console.WriteLine(message);
        }
    }
}
