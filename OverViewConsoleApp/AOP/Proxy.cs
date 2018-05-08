using AspectCore.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;


namespace OverViewConsoleApp.AOP
{
    public class Proxy
    {
    }



    public interface IService
    {
        void Say(string name);
    }

    public class Service : IService
    {
        public void Say(string name)
        {
            Console.WriteLine(name);
        }
    }


    public class InterceptAttribute : AbstractInterceptorAttribute
    {
        public override Task Invoke(AspectContext context, AspectDelegate next)
        {
            context.Parameters[0] =  context.Parameters[0].ToString().ToUpper();
            return next(context);
        }
    }
}
