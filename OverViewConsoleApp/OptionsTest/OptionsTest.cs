using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OverViewConsoleApp.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OverViewConsoleApp.OptionsTest
{
    public class OptionsTest
    {
        public static void OptionsTestLearn()
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile(Path.Combine(Directory.GetCurrentDirectory() + "/appsettings.json")).Build();
            IServiceProvider serviceProvider = new ServiceCollection().AddOptions().Configure<ComplexType>(configuration.GetSection("ComplexType")).BuildServiceProvider();
            var obj = serviceProvider.GetService<IOptions<ComplexType>>()?.Value;
            
        }


        public static void OptionsReLoad()
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile(Path.Combine(Directory.GetCurrentDirectory() + "/appsettings.json"), false, true).Build();
            IServiceProvider serviceProvider = new ServiceCollection().AddOptions().Configure<ComplexType>(configuration.GetSection("ComplexType")).BuildServiceProvider();

            var typeValue = serviceProvider.GetService<IOptionsMonitor<ComplexType>>();
            Console.WriteLine(typeValue.CurrentValue);
            typeValue.CurrentValue.Books.Add(new Book()
            {
                BookId = "0010",
                BookAge = 90
            });
            typeValue.OnChange(p =>
            {
                Console.WriteLine(p);
                Console.WriteLine("changed");
                var newValue = serviceProvider.GetService<IOptionsMonitor<ComplexType>>();
                Console.WriteLine(newValue);
            });
            var typeValue1 = serviceProvider.GetService<IOptionsMonitor<ComplexType>>();
            var result = object.ReferenceEquals(typeValue, typeValue1);
        }
    }
}
