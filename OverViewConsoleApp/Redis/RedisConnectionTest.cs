using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;

namespace OverViewConsoleApp.Redis
{
    public class RedisConnectionTest
    {
        private static readonly ConnectionMultiplexer _connectionMultiplexer = ConnectionMultiplexer.Connect("localhost");
        public static ConnectionMultiplexer connectionMultiplexer
        {
            get
            {
                return _connectionMultiplexer;
            }
        }
        
        static void TestStackExchange()
        {
            var db = connectionMultiplexer.GetDatabase();
        }
    }
}
