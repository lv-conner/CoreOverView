using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OverViewWebApplicaiton.Filters
{
    public class CustomerFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments.TryAdd("id", 1231231);
        }
    }

    public class IdAttribute : Attribute,IFilterFactory
    {
        public bool IsReusable => true;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<CustomerFilter>();
        }
    }
}
