using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyModel;

namespace OverViewConsoleApp.MVC
{
    public static class DIContext
    {
        public static void TestDIContext()
        {
            Assembly asm = Assembly.GetEntryAssembly();
            var dc = DependencyContext.Load(asm);
        }
    }
}
