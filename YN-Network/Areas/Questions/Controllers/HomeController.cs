using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YN_Network.Areas.Questions.Controllers
{
    public class HomeController : Controller
    {
        [Area("Questions")]
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
