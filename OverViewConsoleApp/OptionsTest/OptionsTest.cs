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
    }
}
