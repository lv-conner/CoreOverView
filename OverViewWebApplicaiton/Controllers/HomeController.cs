using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OverViewWebApplicaiton.Models;

namespace OverViewWebApplicaiton.Controllers
{
    /// <summary>
    /// Actions解析。
    /// 1.IRouter(MVCRouteHandler).RouteAsync()
    /// 2.IActionSelector(ActionSelector).SelectCandidates()
    /// 3.IActionDescriptorCollectionProvider(ActionDescriptorCollectionProvider).ActionDescriptors()
    /// 4.IActionDescriptorProvider(ControllerActionDescriptorProvider).OnProvidersExecuting() => GetDescriptors()=>BuildModel() => GetControllerTypes()=>ApplicationPartManager.PopulateFeature()=>ControllerFeatureProvider.PopulateFeature()=>ControllerActionDescriptorBuilder.Build()
    /// 5.IApplicationModelProvider(DefaultApplicationModelProvider).OnProvidersExecuting() => IApplicationModelProvider.OnProvidersExecuted()
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
