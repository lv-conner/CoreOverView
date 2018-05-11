using System;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientGetLryic
{
    class Program
    {
        static string host = "http://www.music.163.com";
        static void Main(string[] args)
        {
            //PostData();
            //CookiePath();
            GetGithubData();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }




        static async void GetData()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:23804/api/person");
            var res = await client.GetAsync("");
            res.EnsureSuccessStatusCode();
            var message = await res.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
        static async void PostData()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:23804/api/person");
            var person = new Person()
            {
                Id = "010",
                Name = "tim"
            };
            var req = new Dictionary<string, string>();
            req.Add("Id", "010");
            req.Add("Name", "tim");
            var urlContent = new FormUrlEncodedContent(req);
            StringContent content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");
            var res = await client.PostAsync("", urlContent);
            res.EnsureSuccessStatusCode();
            var message = await res.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }


        static async void CookiePath()
        {

            var handler = new CustomerHandler();
            handler.UseCookies = true;
            //添加cookie
            handler.CookieContainer.SetCookies(new Uri("https://www.bing.com"), "name=tim");
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://www.bing.com/");
            await client.GetStringAsync("");
            var maxRequstBufferSize = client.MaxResponseContentBufferSize;
            var client1 = new HttpClient();

        }

        static async void GetGithubData()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            client.BaseAddress = new Uri("https://api.github.com");
            var res = await client.GetAsync("");
            //res.EnsureSuccessStatusCode();
            var message = await res.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
    }

    internal class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class CustomerHandler : HttpClientHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
}
