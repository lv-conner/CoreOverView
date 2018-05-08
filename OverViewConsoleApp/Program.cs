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
            var person = new Person()
            {
                Name = "tim",
                Id = "001"
            };
            var stu = new Student()
            {
            };
            Mapper.Initialize(config =>
            {
                config.CreateMap<Person, Student>();
            });
            RequestDelegate
            var obj = Mapper.Map<Student>(person);
            //Logging.TestLogProvider();
            //ConfigurationTest.ConfigurationTestConfig();
            //var person = Activator.CreateInstance(typeof(Person), "tim") as Person;
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
