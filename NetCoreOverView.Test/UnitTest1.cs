using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Diagnostics;

namespace NetCoreOverView.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestDI()
        {
            IServiceProvider serviceProvider = new ServiceCollection().Add(ServiceDescriptor.Transient<ITestService, TestService>()).BuildServiceProvider();
            Assert.True(serviceProvider.GetService<ITestService>().GetType() == typeof(TestService));
        }



        public interface ITestService
        {

        }
        public class TestService:ITestService
        {

        }
    }
}
