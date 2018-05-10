using System;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Encodings.Web;
using System.IO;
using OverViewConsoleApp.Services;
using StackExchange.Redis;
using OverViewConsoleApp.Config;
using WcfServices;
using System.ServiceModel;
using AutoMapper.Configuration;
using AutoMapper.Mappers;
using AutoMapper;
using AutoMapper.Mappers.Internal;
using Microsoft.AspNetCore.Http;

namespace OverViewConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MVCServices.WriteMVCServices();
            Console.ReadKey();
        }


        static async void TestWcfService()
        {
            var client = new NameServiceClient(NameServiceClient.EndpointConfiguration.NameService);
            var message = await client.HelloAsync("tim");
            Console.WriteLine(message);
        }


    }
    public class Person
    {
        public string Name { get; set; }
        public  string Id { get; set; }
        public Person()
        {

        }
    }
    public class Student
    {
        public string Name { get; set; }
    }
}
