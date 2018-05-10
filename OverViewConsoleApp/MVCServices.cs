using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace OverViewConsoleApp
{
    class MVCServices
    {
        public static void WriteMVCServices()
        {

            ServiceCollection services = new ServiceCollection();
            services.AddMvc();
            var text = new StringBuilder();
            foreach (var item in services)
            {
                var a = string.Format("ServiceType:{0}\nImplementType:{1}\nLiftTime:{2}\n", item.ServiceType, item.ImplementationType, item.Lifetime);
                text.Append(a);

            }
            Console.WriteLine(text.ToString());
            File.AppendAllText(@"D:\Service.txt", text.ToString());

        }
    }
}
