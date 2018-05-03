using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OverViewWebApplicaiton.Options;

namespace OverViewWebApplicaiton.Controllers
{
    public class OptionsController : Controller
    {
        private readonly UserProfileOptions _optionsMonitor;
        private readonly UserProfileOptions _options;
        //IOptions与IOptionsMonitor的区别，当Options数据源来自文件等可监控改变的数据事时IOptions获取的值不会根据文件配置中的值改变而改变，IOptionsMonitor的值则会在配置文件改变的时候重新读取数据源。
        //原因在于IOptionsMonitor监听文件改变并在文件改变时去除缓存中的值。因此，需要监听配置改变的不适合使用IOptions；
        public OptionsController(IOptionsMonitor<UserProfileOptions> optionsMonitor,IOptions<UserProfileOptions> options)
        {
            _optionsMonitor = optionsMonitor?.CurrentValue;
            _options = options.Value;
        }
        public IActionResult Index()
        {
            return Json(new { monitor = _optionsMonitor,options = _options });
        }
    }
}