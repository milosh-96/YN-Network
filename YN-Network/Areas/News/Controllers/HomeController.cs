using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YN_Network.Areas.News.Controllers
{
    public class HomeController : Controller
    {
        [Area("News")]
        public IActionResult Index()
        {
            return View();
        }
    }
}