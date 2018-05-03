using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;


namespace OverViewConsoleApp.Config
{
    public class ConfigurationTest
    {
        public static void ConfigurationTestConfig()
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile(Path.Combine(Directory.GetCurrentDirectory() + "/appsettings.json"),false,true).Build();
            var section = configuration.GetSection("ComplexType");
            var obj1 = section.Get<ComplexType>();
            var obj =  configuration.Get<ComplexType>();
        }
    }



    public class ComplexType
    {
        public ComplexType()
        {
            Books = new List<Book>();
        }
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Book> Books { get; set; }
            
    }
        public class Book
        {
            public string BookId { get; set; }
            public int BookAge { get; set; }
        }
}
